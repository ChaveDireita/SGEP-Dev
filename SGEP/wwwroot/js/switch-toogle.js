function trocarElementos(idAparece, idEsconde)
{
    console.log('aparece: ' + idAparece + " esconde " + idEsconde);
   // if ($('#' + idRadio).prop('checked')) {
    $('#' + idAparece).prop('hidden', false);
    $('#' + idEsconde).prop('hidden', true);
    //}
}