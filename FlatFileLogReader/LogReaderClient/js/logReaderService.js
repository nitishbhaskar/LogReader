angular.module('LogReader')
    .service('LogReaderService', logService);

logService.$inject = ['$http', '$rootScope'];

function logService(http, rootScope) {
    var model = {fileNames:'', fileContents: ''};
    return {
        Model: model,
        GetAllFiles: getAllFiles,
        GetFileContents: openFile,
    };

    function getAllFiles() {
        http({ method: 'GET', url: '/api/LogFileNames' })
            .success(function (data) {
                model.fileNames = data;
            });
    }
    
    function openFile(fileName) {
        http({ method: 'GET', url: '/api/GetFileContents?FileName='+fileName })
            .success(function (data) {
                model.fileContents = data;
                model.currentFile = fileName;
            });
    }
}