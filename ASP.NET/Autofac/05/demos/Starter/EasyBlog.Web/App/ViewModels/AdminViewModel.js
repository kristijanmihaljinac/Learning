
var adminViewModel = function () {

    var self = this;

    self.postSubject = ko.observable('');
    self.postBody = ko.observable('');
    self.message = ko.observable('');

    self.submit = function () {
        self.message('');
        var model = {
            PostSubject: self.postSubject(),
            PostBody: self.postBody()
        }
        $.post('/api/blog/post/add', model)
            .done(function (result) {
                self.postSubject('');
                self.postBody('');
                self.message('Post Saved');
            })
            .fail(function (result) {
                alert(result.status + ' :: ' + result.statusText + ' :: ' + JSON.parse(result.responseText).ExceptionMessage);
            });
    }
}
