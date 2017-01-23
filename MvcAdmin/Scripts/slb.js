﻿$(function() {
    var ajaxFormSubmit = function () {
        var $form = $(this);

         
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-slb-target")); // #postList 

            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect( "shake");
       
        });

        return false;
    };


    var submitAutocompleteForm = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    }

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-slb-autocomplete"),
            minLength: 2,
            select: submitAutocompleteForm
        }

        $input.autocomplete(options);
    }


    $("input[data-slb-autocomplete]").each(createAutocomplete);
    $("form[data-slb-ajax='true']").submit(ajaxFormSubmit);

});