$(document).ready(function () {
    $('#track_table').DataTable({
        paging: false
    });
});

function ShowHistory(trackId) {
    var table = $('#trackHistory');
    $('#trackHistoryModalInfo').hide();
    $('#trackHistoryModalLoader').show();
    $('#trackHistoryModal').modal('show');
    $('#trackHistory').DataTable().clear();
    $('#trackHistory').DataTable().destroy();

    $.ajax({
        url: '/Home/GetTrackHistory?trackId=' + trackId,
        success: function (data) {
            for (var i = 0; i < data.races.length; i++) {
                let row = $('<tr></tr>');
                row.append($('<td>' + data.races[i].year + '</td>'));
                row.append($('<td>' + data.races[i].raceNum + '</td>'));
                row.append($('<td>' + data.races[i].name + '</td>'));
                row.append($('<td>' + data.races[i].pole + '</td>'));
                row.append($('<td>' + data.races[i].winner + '</td>'));
                row.append($('<td>' + data.races[i].cautions + '</td>'));
                row.append($('<td><a href="./RaceResults?year=' + data.races[i].year + '&showResults=' + data.races[i].eventId + '" target="_blank">Results</a></td>'));

                table.append(row);
            }
            $('#trackHistoryModalLoader').hide();
            $('#trackHistoryModalInfo').show();
            $('#trackHistoryModalTitle').text(data.races[0].Track);
            $('#trackIcon').attr('src', data.trackIcon);
            $('#trackLayout').attr('src', data.trackLayout);
        }
    });
}