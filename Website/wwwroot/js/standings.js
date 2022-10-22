$(document).ready(function () {
    var week = $('#activeWeek').val();
    var year = $('#activeYear').val(); //$('#year_select option:last').attr('selected', 'selected').val();
    $('#week_select').val(week);
    $('#year_select').val(year);
    $('#cur_year').text(year);
    GetResults(week, year);  

    $('#race_results_link').attr('href', './RaceResults?year=' + $('#year_select option:selected').val());

    $('#week_select').change(function (d) {      
        var week = $('#week_select option:selected').val();
        var year = $('#year_select option:selected').val();  
        GetResults(week, year);
    });

    $('#year_select').change(function (d) {
        var year = $('#year_select option:selected').val();
        $('#cur_year').text(year);
        GetWeeks(year);
        $('#race_results_link').attr('href', './RaceResults?year=' + year);
    });    
});