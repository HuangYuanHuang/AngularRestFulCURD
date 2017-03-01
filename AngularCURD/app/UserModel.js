angular.module("UserModel", ["ngResource", "ngAngularTable"]).factory("UserModel", function ($http, $resource, AngularTable) {
    var main = this;
    //restfullapi 接口 使用微软odata web api 
    var userSevice = $resource('/odata/ApiUser(:userId)', { userId: '@id' }, { 'query': { method: 'GET' } });


    main.defalutUsers = [];
    main.nodes = [];
    main.Edit = null;

    main.addUser = function () {
        main.Edit = new userViewModel("", "", "", "Admin", "", "", "Enable");
        $("#myModalLabel").text("添加用户")
        $("#myModal").modal('show');
    }
    var userViewModel = function (userId, userName, email, role, time, age, status) {
        var self = this;
        self.userId = userId;
        self.userName = userName;
        self.email = email;
        self.role = role;
        self.time = time;
        self.age = age;
        self.status = status;

        //Event;
        self.edit = function () {
            main.Edit = self;
            $("#myModal").modal('show');
            
        }

        self.remove = function () {
            main.nodes.forEach(function (item, index) {
                if (item.userId == self.userId) {
                    main.nodes.splice(index, 1);
                   
                }
            });
        }

        self.save = function () {
            alert("用户" + self.userName+" 保存成功");
        }

    }

    //数据刷新事件
    AngularTable.pageRefreshEvent = function (pageSize, pageNumber) {
        while (main.nodes.length > 0) {
            main.nodes.pop();
        }
        //服务器分页
        //userSevice.query({ $skip: pageSize * (pageNumber - 1), $top: pageSize }, function (response) {
        //    var data = response.value;
        //    while (main.nodes.length > 0) {
        //        main.nodes.pop();
        //    }
        //    for (var c in data) {
        //        main.nodes.push(new userViewModel(data[c].UserID, data[c].UserName, data[c].Email, data[c].UserRole, data[c].CreateTime, data[c].Age, data[c].Status));
        //    }
        //})
        var start = pageSize * (pageNumber - 1);
        var end = start + pageSize;
        if (end >= main.defalutUsers.length) {
            end = main.defalutUsers.length;
        }
        for (var i = start; i < end; i++) {
            main.nodes.push(main.defalutUsers[i]);
        }


    }

    main.init = function () {
        userSevice.query(function (response) {
            var data = response.value;
            for (var c in data) {
                main.defalutUsers.push(new userViewModel(data[c].UserID, data[c].UserName, data[c].Email, data[c].UserRole, data[c].CreateTime, data[c].Age, data[c].Status));
            }
            AngularTable.dataLength = main.defalutUsers.length;
            for (var i = 0; i < AngularTable.pageSize; i++) {
                main.nodes.push(main.defalutUsers[i]);
            }
        })
    }
    return main;
})