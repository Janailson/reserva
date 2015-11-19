using System;
using System.Configuration;

/// <summary>
/// String de conexão com o banco de dados
/// </summary>
public class Conexao
{
    private string _ConexaoBancoDeDados = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
    public string ConexaoBancoDeDados
    {
        get { return _ConexaoBancoDeDados; }
        set { _ConexaoBancoDeDados = value; }
    }
}