            $j = jQuery;
			$j(document).ready(function(){
			    required = ["txtFirstName", "txtLastName", "txtEmailID", "txtPhone", "subject", "cname", "address"];
                    val = ['First Name','Last Name','Email Address','Mobile No','Your Name','',''];
                    email = $j("#txtEmailID");
                	errornotice = $j("#error");
                	// The text to show up within a field when it is incorrect
                	emptyerror = "REQUIRED!";
                	emailerror = "Enter Valid E-mail.";

                	$j("#btnSend").click(function () {
                		//Validate required fields
                		for (i=0;i<required.length;i++) {
                			var input = $j('#'+required[i]);
                			if ((input.val() == "") || (input.val() == emptyerror) || (input.val() == val[i])) {
                				input.addClass("errorcss");
                				input.val(emptyerror);
                				errornotice.fadeIn(750);
                			} else {
                			    input.removeClass("errorcss");
                			}
                		}
                		// Validate the e-mail.
                		if (!/^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/.test(email.val())) {
                		    email.addClass("errorcss");
                			email.val(emailerror);
                		}

                		//if any inputs on the page have the class 'needsfilled' the form will not submit
                		if ($j(":input").hasClass("errorcss")) {
                			return false;
                		} else {
                			errornotice.hide();
                			//return true;
                            $j('#contactUsForm').submit();
                		}
                	});

                	// Clears any fields in the form when the user clicks on them
                	$j(":input").focus(function(){
                	    if ($j(this).hasClass("errorcss")) {
                			$j(this).val("");
                			$j(this).removeClass("errorcss");
                	   }
                	});
                });