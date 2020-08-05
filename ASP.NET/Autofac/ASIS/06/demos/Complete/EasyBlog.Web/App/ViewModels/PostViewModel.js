
var postViewModel = function (blogPostId) {

    var self = this;

    self.blogPost = ko.observable(null);
    self.name = ko.observable('');
    self.email = ko.observable('');
    self.comment = ko.observable('');
    self.message = ko.observable('');
    
    self.loadPost = function () {
        $.get('/api/blog/post/' + blogPostId, null)
            .done(function (result) {
                self.blogPost(ko.mapping.fromJS(result));
            })
            .fail(function (result) {
                alert(result.status + ' :: ' + result.statusText + ' :: ' + JSON.parse(result.responseText).ExceptionMessage);
            });
    }

    self.submit = function () {
        self.message('');
        var model = {
            Name: self.name(),
            Email: self.email(),
            CommentBody: self.comment(),
            BlogPostId: self.blogPost().BlogPostId()
        }
        $.post('/api/blog/comment/add', model)
            .done(function (result) {
                var newComment = ko.observable(ko.mapping.fromJS(result));
                self.blogPost().Comments.push(newComment);
                self.name('');
                self.email('');
                self.comment('');
                self.message('Comment Saved');
            })
            .fail(function (result) {
                alert(result.status + ' :: ' + result.statusText + ' :: ' + JSON.parse(result.responseText).ExceptionMessage);
            });
    }

    self.webFriendly = function (text) {
        return ko.computed(function () {
            return text.split('\r\n').join('<br/>');
        }, self);
    }

    self.loadPost();
}
