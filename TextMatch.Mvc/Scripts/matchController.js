var app = angular.module('textMatchApp', []);

app.controller('TextMatchController', function ($http) {
    var me = this; //needed to access scope inside $http, as i am using an alias

    //send an ajax request to our web api, to compare the text and sub text.
    //display the result to screen
    me.match = function (text, subtext) {
        $http({
            method: 'GET',
            url: '/api/textmatch?text=' + text + '&subtext=' + subtext
        }).then(function success(response) {
            if (response.data.length > 0) {
                me.result = 'Found ' + response.data.length + ' matches, in possitions: ' + response.data;
            }
            else {
                me.result = 'There is no output';
            }
        }, function error(response) {
            me.result = 'Error on http request: ' + response;
        });
    };
});