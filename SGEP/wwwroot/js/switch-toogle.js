function trocarElementos(idSwitch, idEsquerda, idDireita)
{
    if ($('#' + idSwitch).prop('checked')) {
        $('#' + idEsquerda).prop('hidden', true);
        $('#' + idDireita).prop('hidden', false);
    } else
    {
        $('#' + idEsquerda).prop('hidden', false);
        $('#' + idDireita).prop('hidden', true);
    }
}