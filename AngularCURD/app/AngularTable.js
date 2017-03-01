angular.module("ngAngularTable", []).factory("AngularTable", function () {
    var main = this;
    main.dataLength = 0;
    //分页属性
    main.pageSize = 10;
    main.sizeArray = [10, 20, 50, 100];
    main.pageNumber = 1;
    main.pageTotal = function () {
        var num = parseInt(main.dataLength / main.pageSize);
        if (num * main.pageSize < main.dataLength) {
            return num + 1;
        }
        return num;
    }
    main.pageChanged = function () {
        if (main.pageRefreshEvent != null) {
            main.pageRefreshEvent(main.pageSize, main.pageNumber);
        }
    }
    main.pageRefreshEvent = null;
    return main;
});