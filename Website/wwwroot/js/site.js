// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function GetResults(week, year) {
    if(week == undefined || year == undefined) {
        var week = $('#week_select option:selected');
        var year = $('#year_select option:selected');
    }
    var dir = "wwwroot/Data/" + year + "/csv/" + week;
    console.log(dir);
    let table = $('#season_standings tbody');
    $('#season_standings').DataTable().clear();
    $('#season_standings').DataTable().destroy();


    $.ajax({
        url: '/Home/GetStandings?year=' + year + '&raceNum=' + week,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {                
                let row = $('<tr></tr>');
                row.append($('<td>' + (i + 1) + '</td>'));
                row.append($('<td><a href="#" onclick="ShowSeasonModal(' + data[i].driverId + ', ' + year + ', null, $(this).parent().parent());">' + data[i].name + '</a></td>'));
                row.append($('<td style="background-color: ' + data[i].primaryColor + '; border: 1px solid ' + data[i].secondaryColor + ';"><img src="/Images/Icons/' + year + '/' + data[i].number + '.png" style="height: auto; width: 50%;" /></td>'));
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
            

            var standingsTable = $('#season_standings').DataTable({
                paging: false
            }); 

            GetPlayoffsSystem(year);

            if ($('#playoffsSystem').val() == 1) {
                var indexes = standingsTable.rows().eq(0).filter(function (rowIdx) {
                    return standingsTable.cell(rowIdx, 0).data() <= 10 ? true : false;
                });
                standingsTable.rows(indexes)
                    .nodes()
                    .to$()
                    .css('background-color', '#fef000').css('border', '3px solid rgb(190, 186, 0)');
            }
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
                option.val(data[i]);
                option.text(data[i]);
                $('#week_select').append(option);
            }

            $('#week_select option:last').attr('selected', 'selected');
            var week = $('#week_select option:selected').val();
            GetResults(week, year);
        }
    });
}

function GetHeadlines(year) {
    $.ajax({
        url: '/Home/GetHeadlines?year=' + year,
        success: function(data) {
            for(var i = 0; i < data.length; i++) {
                let li = $('<li style="border-bottom: 1px solid white;"></li>');                
                li.text(data[i]);
                $('#headline-list').append(li);
            }
        }
    });
}

function GetUpcoming(year) {
    let table = $('#upcoming-schedule');
    $.ajax({
        url: '/Home/GetUpcomingSchedule?year=' + year,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                let tr = $('<tr></tr>');
                tr.append($('<td>' + data[i].raceNum + '</td>'));
                tr.append($('<td>' + data[i].raceName + '</td>'));
                tr.append($('<td>' + data[i].name + '</td>'));
                table.append(tr);
            }            
        }
    });
}

function GetTrackStats(year) {
    $('#track_stats_info').hide();
    $('#track_stats_loader').show();
    $.ajax({
        url: '/Home/GetUpcomingTrackStats?year=' + year,
        success: function (data) {
            $('#track_img').attr('src', data.image);
            $('#track_length').text(data.trackLength + " mi");
            $('#track_type').text(data.trackType);
            $('#race_laps').text(data.laps);
            $('#prev_winner').text(data.previousWinner);
            $('#track_wins').text(data.mostWins);
            $('#track_laps').text(data.mostLed);

            $('#track_stats_loader').hide();
            $('#track_stats_info').show();
        }
    })
}

function GetHeadlinesFromServer() {
    $.ajax({
        url: '/Home/GetHeadlines',
        success: function (data) {
            console.log(data);
            for (var i = 0; i < data.length; i++) {
                $('#headline-list').append($('<li style="border-bottom: 1px solid #AAA; padding: 0.5em;">' + data[i] + '</li>'));
            }
        }
    })
}

function GetPlayoffsSystem(year) {
    $.ajax({
        url: '/Home/GetPlayoffsSystem?year=' + year,
        success: function (data) {
            if (data.playoffId == 1) {
                $('#cup_desc').html('<img src="/Images/ChaseForTheCup.png" style="width: 25%;" />');
                $('#playoffsSystem').val(data.playoffId);
                $('#standings_type_text').html('Chase');
                $('#standings_guide').css('display', 'block');
            } else {
                $('#cup_desc').html('PRL Cup');
                $('#playoffsSystem').val(0);
                $('#standings_guide').css('display', 'none');
            }
        }
    });
}
