function DateTimeFormatter(value, row) {
    if (value == undefined) {
        return "";
    }
    /*json格式时间转js时间格式*/
    value = value.substr(1, value.length - 2);
    var obj = eval('(' + "{Date: new " + value + "}" + ')');
    var dateValue = obj["Date"];
    if (dateValue.getFullYear() < 1900) {
        return "";
    }
    return dateValue.toLocaleString();
}

function BoolFormat(value, row) {
    if (value == undefined) {
        return unchecked;
    }
    return value == true ? checked : unchecked;
}

function CreateIFame(src) {
    var iframe = "<iframe width='100%' height='99%' scrolling='no' frameborder='0' src='" + src + "'></iframe>";
    return iframe;
}


function OpenIFame(title, url) {
    var node = $('#tt').tree('getSelected');
    if (node) {
        $('#dialog').dialog(
        {
            title: title,
            width: 600,
            height: 400,
            closed: false,
            cache: false,
            modal: true,
            onClose: function () {
                $('#tt').tree('reload');
                $('#tt').tree('scrollTo', node.target);
            },
            content: CreateIFame(url + node.id)
        });
    }
}