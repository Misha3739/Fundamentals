
$(function () {
        function Tree() {
            var $this = this;

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
                treeNodeClick();
            }
        }

            $(function() {
                var self = new Tree();
                self.init();
            });
        });
  