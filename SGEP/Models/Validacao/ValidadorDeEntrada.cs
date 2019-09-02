using System;
using System.Text.RegularExpressions;

namespace SGEP.Models.Validacao
{
  public sealed class ValidadorDeEntrada
  {
  	private ValidadorDeEntrada () {}

  	public static bool VerificarTelefone (string entrada)
  	{
  		Regex Expressao = new Regex ("([0-9]{8})|([0-9]{9})");
  		return Expressao.IsMatch (entrada);
  	}

  	public static bool VerificarData (string entrada)
  	{
  		Regex Expressao = new Regex ("([012][0-9]/(([0][0-9])|([1][12]))/([0-9]{4}))|"
  							   +"([012][0-8]/2/([0-9]{4}))|"
  							   +"(30/((0[13456789])|(1[12]))/([0-9]{4}))|"
  							   +"(31/((0[13578])|(1[02]))/([0-9]{4}))");
  		string s = "";
  		s += ("" + entrada[6] + entrada[7] + entrada[8] + entrada[9]);

  		if (Convert.ToInt32 (s)%4 != 0 && Convert.ToInt32 ("" + entrada[0] + entrada[1]) == 29 && Convert.ToInt32 ("" + entrada[3] + entrada[4]) == 2)
  			return false;

  		return Expressao.IsMatch (entrada);
  	}

  	public static bool VerificarEmail (string entrada)
  	{
  		Regex Expressao = new Regex (@"[0-9a-z]+@([a-z]+\.){1,2}[a-z^\.]+");

  		return Expressao.IsMatch (entrada);
  	}
  }
}
