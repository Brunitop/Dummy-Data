using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace WindowsFormsDummyData
{
    public partial class Form1 : Form
    {
        string[] apellidoespanol = { "García", "Rodríguez", "López", "Martínez", "Pérez", "Gómez", "Sánchez", "Díaz", "Hernández", "López", "González", "Álvarez", "Fernández", "Muñoz", "Romero", "Suárez", "Torres", "Domínguez", "Vázquez", "Ramos" };
        string[] apellidoingles = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin" };
        string[] apellidochino = { "王", "李", "张", "刘", "陈", "杨", "黄", "吴", "赵", "周", "徐", "孙", "马", "朱", "胡", "林", "郭", "何", "高", "罗" };
        string[] apellidoruso = { "Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев", "Петров", "Соколов", "Михайлов", "Новиков", "Федоров", "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов", "Егоров", "Павлов", "Козлов", "Степанов", "Николаев" };
        string[] nombresarray = {
            // Español
            "Juan", "María", "Carlos", "Laura", "Pedro", "Ana", "Luis", "Sofía", "Diego", "Valeria",
            "Alejandro", "Paula", "José", "Camila", "Andrés", "Lucía", "Miguel", "Isabella", "Fernando", "Valentina",
            // Inglés
            "James", "Emma", "William", "Olivia", "Alexander", "Ava", "Michael", "Sophia", "Daniel", "Emily",
            "David", "Mia", "Matthew", "Charlotte", "John", "Amelia", "Joseph", "Ella", "Christopher", "Grace",
            // Ruso
            "Иван", "Анна", "Дмитрий", "Екатерина", "Александр", "Мария", "Артем", "Александра", "Михаил", "София",
            "Николай", "Алина", "Сергей", "Елена", "Андрей", "Виктория", "Павел", "Анастасия", "Максим", "Кристина",
            // Chino
            "伟", "蕾", "文强", "丽", "敏", "强", "秀兰", "敏", "刚", "秀英",
            "杰", "娜", "军", "燕", "健", "玲", "涛", "静", "宇", "芳"
        };

        public Form1()
        {
            InitializeComponent();
        }

        private List<Alumno> GenerateDummyData(int numRecords)
        {
            Random random = new Random();
            List<Alumno> alumnos = new List<Alumno>();

            for (int i = 0; i < numRecords; i++)
            {
                // Apellido1: escoger uno de los 4 arreglos aleatoriamente y uno de los elementos del arreglo escogido
                string apellido1 = "";
                switch (random.Next(4))
                {
                    case 0:
                        apellido1 = apellidoespanol[random.Next(apellidoespanol.Length)];
                        break;
                    case 1:
                        apellido1 = apellidoingles[random.Next(apellidoingles.Length)];
                        break;
                    case 2:
                        apellido1 = apellidochino[random.Next(apellidochino.Length)];
                        break;
                    case 3:
                        apellido1 = apellidoruso[random.Next(apellidoruso.Length)];
                        break;
                }

                // Apellido2: escoger uno de los 4 arreglos aleatoriamente y uno de los elementos del arreglo escogido
                string apellido2 = "";
                switch (random.Next(4))
                {
                    case 0:
                        apellido2 = apellidoespanol[random.Next(apellidoespanol.Length)];
                        break;
                    case 1:
                        apellido2 = apellidoingles[random.Next(apellidoingles.Length)];
                        break;
                    case 2:
                        apellido2 = apellidochino[random.Next(apellidochino.Length)];
                        break;
                    case 3:
                        apellido2 = apellidoruso[random.Next(apellidoruso.Length)];
                        break;
                }

                // Nombres: escoger dos de los nombres aleatoriamente y combinarlos en una sola cadena llamada
                string nombre1 = nombresarray[random.Next(nombresarray.Length)];
                string nombre2 = nombresarray[random.Next(nombresarray.Length)];
                string nombres = nombre1 + " " + nombre2;

                // Correo: tomar el apellido 1, el apellido2 o ambos. Agregar un numero al final entre 0 y 999
                // Formato: 'appellido(s)''numero'@'gmail.com'
                string correo = "";
                int randomNumber = random.Next(1000);
                int choice = random.Next(3); // 0: apellido1, 1: apellido2, 2: ambos
                switch (choice)
                {
                    case 0:
                        correo = apellido1 + randomNumber + "@gmail.com";
                        break;
                    case 1:
                        correo = apellido2 + randomNumber + "@gmail.com";
                        break;
                    case 2:
                        correo = apellido1 + apellido2 + randomNumber + "@gmail.com";
                        break;
                }

                // FechaNacimiento: tomar una fecha entre 01-01-1980 a 31-12-2010
                DateTime fechaNacimiento = new DateTime(1980, 1, 1).AddDays(random.Next(11688)); // 11688 días es el rango entre 01-01-1980 a 31-12-2010

                // Crear el objeto Alumno y agregarlo a la lista de alumnos
                Alumno alumno = new Alumno(apellido1, apellido2, nombres, correo, fechaNacimiento);
                alumnos.Add(alumno);
            }

            return alumnos;
        }

        private DateTime RandomDay()
        {
            DateTime start = new DateTime(1990, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(new Random().Next(range));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tablaAlumnos.Columns.Add("Matricula", "Matrícula");
            tablaAlumnos.Columns.Add("Apellido1", "Apellido 1");
            tablaAlumnos.Columns.Add("Apellido2", "Apellido 2");
            tablaAlumnos.Columns.Add("Nombres", "Nombres");
            tablaAlumnos.Columns.Add("Correo", "Correo");
            tablaAlumnos.Columns.Add("FechaNacimiento", "Fecha de Nacimiento");
        }

        private void txtNumRecords_TextChanged(object sender, EventArgs e)
        {

        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            int numRecords;
            if (!int.TryParse(txtNumRecords.Text, out numRecords) || numRecords < 1 || numRecords > 50000)
            {
                MessageBox.Show("Please enter a valid number of records between 1 and 50,000.");
                return;
            }

            // Limpiar la tabla de alumnos antes de agregar nuevos registros
            tablaAlumnos.Rows.Clear();

            // Generate dummy data
            List<Alumno> alumnos = GenerateDummyData(numRecords);

            foreach (var alumno in alumnos)
            {
                tablaAlumnos.Rows.Add(alumno.Matricula, alumno.Apellido1, alumno.Apellido2, alumno.Nombres, alumno.Correo, alumno.FechaNacimiento);
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

            // Iterar sobre las filas de la tabla y extraer los datos
            foreach (DataGridViewRow row in tablaAlumnos.Rows)
            {
                // Crear un diccionario para almacenar los datos de la fila actual
                Dictionary<string, object> rowData = new Dictionary<string, object>();

                // Iterar sobre las celdas de la fila y agregar los datos al diccionario
                foreach (DataGridViewCell cell in row.Cells)
                {
                    rowData[cell.OwningColumn.Name] = cell.Value;
                }

                // Agregar el diccionario de datos a la lista
                data.Add(rowData);
            }

            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

            // Save JSON to file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON File|*.json";
            saveFileDialog.Title = "Save JSON File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, json);
                MessageBox.Show("JSON file has been exported successfully.");
            }
        }
    }

    public class Alumno
    {
        public string Matricula { get; }
        public string Apellido1 { get; }
        public string Apellido2 { get; }
        public string Nombres { get; }
        public string Correo { get; }
        public DateTime FechaNacimiento { get; }

        public Alumno(string apellido1, string apellido2, string nombres, string correo, DateTime fechaNacimiento)
        {
            Matricula = Guid.NewGuid().ToString();
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Nombres = nombres;
            Correo = correo;
            FechaNacimiento = fechaNacimiento;
        }
    }
}
