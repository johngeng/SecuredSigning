function ViewModel() {
    var self = this;

    self.firstName = ko.observable().extend({
        required: true,
        minLength: 2,
    });
    self.lastName = ko.observable().extend({ required: true, minLength: 2, maxLength: 20 });
    self.fullAddress = ko.observable().extend({ required: true, minLength: 5, maxLength: 50 });
    self.mailingAddressAsAbove = ko.observable();
    self.emailAddress = ko.observable().extend({ required: true, email: true });
    self.phoneNumber = ko.observable().extend({
        required: true,
        pattern: {
            params: /^(?=.*[0-9])[- +()0-9]+$/,
            message: "Invalid phone number."
        }
    });
    self.citizenshipStatus = ko.observable().extend({ required: true });
    self.employmentStartDate = ko.observable().extend({ required: true });
    self.employmentType = ko.observable().extend({ required: true });
    self.positionTitle = ko.observable().extend({ required: true });
    self.emergencyContactName = ko.observable().extend({ required: true });
    self.emergencyContactRelationship = ko.observable().extend({ required: true });
    self.emergencyContactPhoneNumber = ko.observable().extend({
        required: true,
        pattern: {
            params: /^(?=.*[0-9])[- +()0-9]+$/,
            message: "Invalid phone number."
        }
    });

    self.processing = ko.observable(false);
    self.hasBeenSubmitted = ko.observable(false);
    self.formId = ko.observable();
    self.pdfURL = ko.observable();

    self.handleSubmit = function () {
        self.processing(true);

        //Check for errors      
        var errors = ko.validation.group(self);
        if (errors().length > 0) {
            errors.showAllMessages();

            self.processing(false);
            return;
        }

        var data = ko.toJSON(self);

        $.ajax({
            url: "https://securedsigning-api.azurewebsites.net/api/form",
            type: "POST",
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                self.formId(result);
                if (self.formId != 0) {
                    self.hasBeenSubmitted(true);

                    console.log(self.formId);
                    generatePDF(document.documentElement.outerHTML, self);

                    $('html, body').animate({
                        scrollTop: $("#summary").offset().top
                    }, 1000);

                    self.processing(false);
                }
            }
        });
    }
};

ko.applyBindings(new ViewModel());

function generatePDF(html, viewModel) {
    var data = {
        "html": html,
        "inline": true,
        "fileName": "EmployeeForm.pdf",
        "options": {
            "delay": 0,
            "usePrintCss": true,
            "landscape": false,
            "printBackground": true
        }
    };
    $.ajax({
        type: "POST",
        beforeSend: function (request) {
            request.setRequestHeader("Authorization", "aec28d1d-d7c5-4f49-b1b8-6457ec2d4515");
        },
        url: "https://v2.api2pdf.com/chrome/pdf/html",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            viewModel.pdfURL(result.FileUrl);
        }
    });
}