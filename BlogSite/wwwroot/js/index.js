$().ready(function() {

  $('.js--scroll-to-boom').click(function() {
    $('html, body').animate({scrollTop: $('.js--section-boom').offset().top}, 1000);
  })

});