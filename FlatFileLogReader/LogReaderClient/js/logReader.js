angular
    .module('LogReader', []);

angular
    .module('LogReader')
    .controller('LogReaderController', MainCtrl);

function MainCtrl(scope, LogReaderService) {
    scope.LogReaderService = LogReaderService;
    LogReaderService.GetAllFiles();
}

MainCtrl.$inject = ['$scope', 'LogReaderService'];