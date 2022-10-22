$(document).ready(function () {
    //GetHeadlines($('#cur_year').text());
    //GetTop10($('#cur_year').text());
    GetUpcoming($('#cur_year').text());
    GetHeadlinesFromServer();
    GetTrackStats($('#cur_year').text());
    $('#race_results_link').attr('href', './Home/RaceResults?year=' + $('#cur_year').text()); 
    $('#full-schedule-link').attr('href', './Home/RaceResults?year=' + $('#cur_year').text());
});