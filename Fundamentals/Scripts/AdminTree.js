
$(function () {
        function Tree() {
            var $this = this;
            
            function MarkUnapprovedRoles() {
                 var parents = $("#frm-author").find(".li-parent");
                 for (var parent of parents) {
                     var adminApproved = $(parent).children("a").children(".user-admin-approved").prop("value");
                     if (adminApproved == "False") {
                         var parentHead = $(parent).children("a");
                         parentHead.addClass("not-approved");


                         var children = $(parent).children("ul").children("li .li-child").children("a");
                         children.addClass("not-approved");
                     }
                }
            }

            function treeNodeClick() {
                $(document).on('click',
                    '.tree li a input[type="checkbox"]',
                    function () {
                        var selected = $(this);

                        //set User's IsDirty
                        var userNode = selected.parents(".li-parent");
                        var userIsDirty = userNode.children("a").children(".input-dirty-parent");
                        userIsDirty.prop("value", true);

                        //set Child IsDirty
                        var roleIsDirty = selected.parents(".li-child").children(".input-dirty-child");
                        var roleIsAssigned = selected.parents(".li-child").children(".input-assigned-child");
                        var isAssigned = roleIsAssigned.prop("value");
                        var isChecked = selected.prop("checked");
                        var isDirty = isChecked != isAssigned;
                        roleIsDirty.prop("value",isDirty);


                    });
            }
          

            $this.init = function () {
                MarkUnapprovedRoles();
                treeNodeClick();
            }
        }

            $(function() {
                var self = new Tree();
                self.init();
            });
        });
  