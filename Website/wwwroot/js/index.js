$(document).ready(function () {
    var week = $('#week_select option:last').attr('selected', 'selected').val();
    var year = $('#year_select option:last').attr('selected', 'selected').val();
    $('#cur_year').text(year);
    GetResults(week, year);  

    GetTop10($('#year_select option:selected').val());
    $('#race_results_link').attr('href', './Home/RaceResults?year=' + $('#year_select option:selected').val());

    $('#week_select').change(function (d) {      
        var week = $('#week_select option:selected').val();
        var year = $('#year_select option:selected').val();  
        GetResults(week, year);
    });

    $('#year_select').change(function (d) {
        var year = $('#year_select option:selected').val();
        $('#cur_year').text(year);
        GetWeeks(year);
        $('#race_results_link').attr('href', './Home/RaceResults?year=' + year);
    });    
});