$(document).ready(function () {
    $('#trackHistoryModal').modal();
    if ($('#raceToShow').val() != 0) {
        ShowResults($('#raceToShow').val());
    }
});

function ShowResults(eventId) {
    var table = $('#resultsTable');
    $('#resultsModalInfo').hide();
    $('#resultsModalLoader').show();
    $('#resultsModal').modal('show');
    $('#resultsTable').DataTable().clear();
    $('#resultsTable').DataTable().destroy();

    $.ajax({
        url: '/Home/GetRaceResults?eventId=' + eventId,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                let row = $('<tr></tr>');
                row.append($('<td>' + data[i].finish + '</td>'));
                row.append($('<td>' + data[i].start + '</td>'));
                row.append($('<td>' + data[i].driverName + '</td>'));
                row.append($('<td>' + data[i].number + '</td>'));
                row.append($('<td>' + data[i].laps + '</td>'));
                row.append($('<td>' + data[i].led + '</td>'));
                row.append($('<td>' + data[i].points + '</td>'));
                row.append($('<td>' + data[i].status + '</td>'));

                table.append(row);
            }

            $('#resultsTable').DataTable({
                paging: false
            });
            $('#resultsModalLoader').hide();
            $('#resultsModalInfo').show();
            $('#fullResultsLink').attr('href', data[0].htmlFile);
            $('#resultsModalTitle').text(data[0].raceName);
        }
    });
}