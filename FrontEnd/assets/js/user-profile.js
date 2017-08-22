$(document).ready(function() {
    $('.date-picker').each(function() {
        $(this).datepicker({
            templates: {
                leftArrow: '<i class="now-ui-icons arrows-1_minimal-left"></i>',
                rightArrow: '<i class="now-ui-icons arrows-1_minimal-right"></i>'
            }
        }).on('show', function() {
            $('.datepicker').addClass('open');

            datepicker_color = $(this).data('datepicker-color');
            if (datepicker_color.length != 0) {
                $('.datepicker').addClass('datepicker-' + datepicker_color + '');
            }
        }).on('hide', function() {
            $('.datepicker').removeClass('open');
        });
    });
    var width = $(window).width();
    if (width < 768) {
        $(".form-control").each(function() {
            $(this).removeClass("form-control-lg");
        })
        $(".col-form-label").each(function() {
            $(this).removeClass("col-form-label-lg");
        })
    }
    $(window).on('resize orientationChange', function(event) {
        var width = $(window).width();
        if (width < 768) {
            $(".form-control").each(function() {
                $(this).removeClass("form-control-lg");
            })
            $(".col-form-label").each(function() {
                $(this).removeClass("col-form-label-lg");
            })
        } else {
            $(".form-control").each(function() {
                $(this).addClass("form-control-lg");
            })
            $(".col-form-label").each(function() {
                $(this).addClass("col-form-label-lg");
            })
        }
    });
})