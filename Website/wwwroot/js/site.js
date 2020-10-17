// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function GetResults(week, year) {
    if(week == undefined || year == undefined) {
        var week = $('#week_select option:selected');
        var year = $('#year_select option:selected');
    }
    var dir = "Data\\" + year + "\\csv\\" + week;
    console.log(dir);
    let table = $('#season_standings tbody');
    $('#season_standings').DataTable().clear();
    $('#season_standings').DataTable().destroy();


    $.ajax({
        url: '/Home/GetStandings?dir=' + dir,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {                
                let row = $('<tr></tr>');
                row.append($('<td>' + (i + 1) + '</td>'));
                row.append($('<td>' + data[i].name + '</td>'));
                row.append($('<td><img src="/Images/Icons/' + year + '/' + data[i].number + '.png" style="height: auto; width: 50%;" /></td>'));
                row.append($('<td>' + data[i].points + '</td>'));
                row.append($('<td>' + (data[i].points - data[0].points) + '</td>'));
                row.append($('<td>' + data[i].starts + '</td>'));
                row.append($('<td>' + data[i].wins + '</td>'));
                row.append($('<td>' + data[i].top5 + '</td>'));
                row.append($('<td>' + data[i].top10 + '</td>'));
                row.append($('<td>' + data[i].dnf + '</td>'));
                row.append($('<td>' + data[i].lapsLed + '</td>'));
                row.append($('<td>' + data[i].laps + '</td>'));

                let sum = 0;
                for (var f = 0; f < data[i].finishes.length; f++) {
                    sum = sum + data[i].finishes[f];
                }

                row.append($('<td>' + (sum / data[i].starts).toPrecision(4) + '</td>'));

                table.append(row);

                
            }
            

            $('#season_standings').DataTable({
                paging: false
            }); 
        }
    });
}

function GetWeeks(year) {
    $('#week_select').empty();

    $.ajax({
        url: '/Home/GetWeeks?year=' + year,
        success: function(data) {
            for(var i = 0; i < data.length; i++) {
                let option = $('<option></option>');
                option.val(data[i].substring(data[i].length - 4));
                option.text(data[i].substring(data[i].length - 4));
                $('#week_select').append(option);
            }

            $('#week_select option:last').attr('selected', 'selected');
            var week = $('#week_select option:selected').val();
            GetResults(week, year);
        }
    });
}
