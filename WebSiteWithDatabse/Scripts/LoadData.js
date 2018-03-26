$().ready(function () {

    var dropdown = $("#ddlDepartments");
    LoadingMessages(dropdown);
    $.ajax({
        type: "POST",
        url: "webmethod1.aspx/GetDepartments",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            BindDepartment(msg);
        },
        error: function () {
            ErrorMessage(msg, dropdown);
        }
    });
});

function GetEmployeeName() {

    var departmentID = $("#ddlDepartments").val();
    if (departmentID > 0) {
        var dropdown = $("#ddlEmployeeName");
        LoadingMessages(dropdown);
        $.ajax({
            type: "POST",
            url: "webmethod1.aspx/GetEmployeeNames",
            data: "{departmentID:" + departmentID + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                BindEmployee(msg);
            },
            error: function () {
                ErrorMessage(msg, dropdown);
            }
        });
    }
    else {
        $("#ddlEmployeeName").get(0).options.length = 0;
    }
}

function LoadingMessages(dropdown) {
    dropdown.get(0).options.length = 0;
    dropdown.get(0).options[0] = new Option("Loading data", "-1");
}

function BindDepartment(msg) {

    //to add select on top of drop down
    $("#ddlDepartments").get(0).options.length = 0;
    $("#ddlDepartments").get(0).options[0] = new Option("Select department", "-1");

    //Bind department value/ text to dropdwon
    $.each(msg.d, function (index, item) {
        $("#ddlDepartments").get(0).options[$("#ddlDepartments").get(0).options.length] = new Option(item.Display, item.Value);
    });
}



function BindEmployee(msg) {
    //to add select on top of drop down
    $("#ddlEmployeeName").get(0).options.length = 0;
    $("#ddlEmployeeName").get(0).options[0] = new Option("Select name", "-1");

    $("#ddlEmployeeName").attr("disabled", false);

    //Bind employeename value/ text to dropdwon
    $.each(msg.d, function (index, item) {
        $("#ddlEmployeeName").get(0).options[$("#ddlEmployeeName").get(0).options.length] = new Option(item.Display, item.Value);
    });
}


function ErrorMessage(msg, dropdown) {
    dropdown.get(0).options.length = 0;
    alert("Failed to load data");
}

