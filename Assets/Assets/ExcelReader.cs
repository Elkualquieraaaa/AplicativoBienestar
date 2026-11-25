using System.IO;
using System.Data;
using System.Text;
using UnityEngine;
using ExcelDataReader;

public class ExcelReader : MonoBehaviour
{
    public Organizer Organizer;
    public string ruta = "C:\\Users\\PERSONAL\\AplicativoBienestar\\Assets\\Templates\\Inscripción I Convocatoria Apoyos de sostenimiento 2026 (respuestas)[plantilla].xlsx";

    void Start()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);


        if (!File.Exists(ruta))
        {
            Debug.LogError("No se encontró el archivo en: " + ruta);
            return;
        }
    }

    [ContextMenu ("ReadLine1")]
    void LeerArchivoExcel()
    {
        using (FileStream stream = File.Open(ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
            {
                DataSet resultado = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                DataTable tabla = resultado.Tables[0];

                Debug.Log($"Pestaña: {tabla.TableName} | Total filas: {tabla.Rows.Count}");


                if (tabla.Rows.Count > 0)
                {

                    for (int i = 0; i < tabla.Rows.Count; i++)
                    {
                        Organizer.AddInformation(tabla.Rows[i][3].ToString(), CreateIC(tabla,i));

                    }
                }
            }
        }
    }

    public InformationClass CreateIC(DataTable Tabla,int ActualRow)
    {
        InformationClass Content = new InformationClass();

        Content.MarcaDeTiempo = Tabla.Rows[ActualRow][0].ToString();
        Content.NombreCompleto = Tabla.Rows[ActualRow][1].ToString();
        Content.TipoDocumento = Tabla.Rows[ActualRow][2].ToString();
        Content.FechaDeNacimiento = Tabla.Rows[ActualRow][4].ToString();
        Content.FechaDeExpedicion = Tabla.Rows[ActualRow][5].ToString();
        Content.Genero = Tabla.Rows[ActualRow][6].ToString();
        Content.NumeroDeFicha = Tabla.Rows[ActualRow][7].ToString();
        Content.Modalidad = Tabla.Rows[ActualRow][8].ToString();
        Content.Programa = Tabla.Rows[ActualRow][9].ToString();
        Content.Jornada = Tabla.Rows[ActualRow][10].ToString();
        Content.NivelFormacion = Tabla.Rows[ActualRow][11].ToString();
        Content.Centro = Tabla.Rows[ActualRow][12].ToString();
        Content.Correo = Tabla.Rows[ActualRow][13].ToString();
        Content.Telefono = Tabla.Rows[ActualRow][14].ToString();
        Content.AlternativaTelefono = Tabla.Rows[ActualRow][15].ToString();
        Content.Direccion = Tabla.Rows[ActualRow][16].ToString();
        Content.DocumentoDeIdentidad = Tabla.Rows[ActualRow][17].ToString();
        Content.FichaSocioeconimica = Tabla.Rows[ActualRow][18].ToString();
        Content.FotocopiaDeRecibo = Tabla.Rows[ActualRow][19].ToString();
        Content.CertificadoEPS = Tabla.Rows[ActualRow][20].ToString();
        Content.CertificadoVDCA = Tabla.Rows[ActualRow][21].ToString();
        Content.PutajeSisben = Tabla.Rows[ActualRow][22].ToString();
        Content.CertificadoPoblacionCampesino = Tabla.Rows[ActualRow][23].ToString();
        Content.CertificadoNARPROM = Tabla.Rows[ActualRow][24].ToString();
        Content.CertificadoDiscapacidad = Tabla.Rows[ActualRow][25].ToString();
        Content.CertificadoMadreoPadre = Tabla.Rows[ActualRow][26].ToString();
        Content.CertificadoEmbarazo = Tabla.Rows[ActualRow][27].ToString();
        Content.VIctimaDeViolecia = Tabla.Rows[ActualRow][28].ToString();
        Content.Desplazamiento = Tabla.Rows[ActualRow][29].ToString();
        Content.Vocero = Tabla.Rows[ActualRow][30].ToString();
        Content.AprendizSemillero = Tabla.Rows[ActualRow][31].ToString();
        Content.TipoDeCuenta = Tabla.Rows[ActualRow][32].ToString();
        Content.Entidad = Tabla.Rows[ActualRow][33].ToString();
        Content.NumeroCuenta = Tabla.Rows[ActualRow][34].ToString();
        Content.CertificadoCuenta = Tabla.Rows[ActualRow][35].ToString();

        return Content;
    }
}