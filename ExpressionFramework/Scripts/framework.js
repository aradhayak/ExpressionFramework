$(document).ready(
    function () {
        $(".editor").val('');
        $(".list li,.list li ul li").on('click', function () {

            var text = '';
            var initialValue = $(".editor").val();

            var parents = $(this).parents("li");

            if (!$(this).children().length > 0 && !parents.length > 0) {
                var x = $(".editor").val().trim();
                if (typeof x == "undefined")
                    x = '';

                text = x + ((x == '') ? "" : ".") + $(this).text().trim();
                $(".editor").val(text);
            }
            else {
                var parentText = '';
                if (parents.length > 0) {
                    $.each(parents, function () {
                        var textP = $($(this).find(".tag")[0]).attr("property");
                        parentText = ((parentText == '') ? "" : ".") + textP.trim();
                    });

                    if (parentText.charAt(0) == '.')
                        parentText = parentText.substring(1, parentText.length);

                    text = initialValue + parentText + ((parentText == '') ? "" : ".") + $(this).attr("property");
                    $(".editor").val(initialValue + '.' + text);
                }
            }



        });
    }

);
