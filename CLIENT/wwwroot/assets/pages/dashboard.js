/*
 Template Name: Admiria - Bootstrap 4 Admin Dashboard
 Author: Themesbrand
 File: Dashboard Init
*/


!function($) {
    "use strict";

    var Dashboard = function() {};

    Dashboard.prototype.init = function () {

        // Peity line
        $('.peity-line').each(function() {
            $(this).peity("line", $(this).data());
        });

        //Knob chart
        $(".knob").knob();

        //C3 combined chart
        c3.generate({
            bindto: '#combine-chart',
            data: {
                columns: [
                    ['OIP', 30, 20, 50, 40, 60, 50, 40, 20, 80, 50, 11, 30],
                    ['KM', 200, 130, 90, 240, 130, 220, 150, 200, 120, 190, 300, 150],
                    ['EKU', 300, 200, 160, 400, 250, 250, 400, 150, 220, 120, 150, 180]
                ],
                types: {
                    OIP: 'bar',
                    KM: 'bar',
                    EKU: 'bar',
                },
         
            },
            axis: {
                x: {
                    type: 'category',
                    categories: ["January", "February", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember"]
                }
            }
        });

        //C3 Donut Chart
        c3.generate({
            bindto: '#donut-chart',
            data: {
                columns: [
                    ['Desktops', 78],
                    ['Mobiles', 40],
                    ['Tablets', 25]
                ],
                type : 'donut'
            },
            donut: {
                title: "Sales Analytics",
                width: 30,
                label: {
                    show:false
                }
            },
            color: {
                pattern: ["#5468da", "#4ac18e","#6d60b0"]
            }
        });

    },
        $.Dashboard = new Dashboard, $.Dashboard.Constructor = Dashboard

}(window.jQuery),

//initializing
    function($) {
        "use strict";
        $.Dashboard.init()
    }(window.jQuery);