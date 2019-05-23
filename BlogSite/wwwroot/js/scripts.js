$(function(){
    var allUsers = $('#allUsers').text().split(' ');
    $('#register').click(function(e){
        if($('#password1').val() != $('#password2').val()) {
            e.preventDefault();
            $('#error-username').hide();
            $('#error-password').show();
        }
        if(allUsers.includes($('#username').val())) {
            e.preventDefault();
            $('#error-password').hide();
            $('#error-username').show();
        }
    });
});