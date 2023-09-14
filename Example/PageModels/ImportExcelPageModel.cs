using Example.Domain.Entities.Persistence;
using Example.Pages;
using FreshMvvm;
using NPOI.HSSF.UserModel; // Para archivos .xls
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel; // Para archivos .xlsx
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Example.PageModels
{
    public class ImportExcelPageModel : FreshBasePageModel
    {
        private string[,] _data;

        public string[,] Data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    OnPropertyChanged(nameof(Data));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ICommand SelectExcel => new Command(OnSelectExcel);

        public async void OnSelectExcel()
        {
            try
            {
                var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.Android, new[] { ".xlsx", ".xls" } },
                    { DevicePlatform.UWP, new[] { ".xlsx", ".xls" } },
                });

                var file = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = customFileType,
                    PickerTitle = "Seleccionar archivo Excel",
                });

                if (file != null)
                {
                    using (var stream = await file.OpenReadAsync())
                    {
                        IWorkbook workbook;
                        if (file.FileName.EndsWith(".xlsx"))
                        {
                            workbook = new XSSFWorkbook(stream);
                        }
                        else if (file.FileName.EndsWith(".xls"))
                        {
                            workbook = new HSSFWorkbook(stream);
                        }
                        else
                        {
                            await CoreMethods.DisplayAlert("Error", "El archivo no es un archivo Excel válido.", "Aceptar");
                            return;
                        }

                        // Ahora puedes leer y procesar los datos del archivo Excel
                        // Por ejemplo, puedes recorrer las hojas y las celdas aquí.
                        // No olvides manejar errores y excepciones adecuadamente.

                        ISheet sheet = workbook.GetSheetAt(0); // Obtén la primera hoja de trabajo (puedes cambiar el índice según la hoja que quieras)
                        string[,] data = new string[sheet.LastRowNum + 1, sheet.GetRow(0).Cells.Count];
                        for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
                        {
                            IRow row = sheet.GetRow(rowIndex);
                            if (row != null)
                            {
                                //TODO: Sirve para carga masiva de usuarios, con columnas nombre, documento, contraseña y rol
                                /**
                                ICell cell = row.GetCell(0);
                                string nombre = cell.ToString();
                                cell = row.GetCell(1);
                                string ced = cell.ToString();
                                cell = row.GetCell(2);
                                string cont = cell.ToString();
                                cell = row.GetCell(3);
                                string rol = cell.ToString();
                                UserApp user = new UserApp() { 
                                    Name = nombre,
                                    Document = Int32.Parse(ced),
                                    Password = cont,
                                    Rol = rol
                                };
                                 */

                                // TODO: En caso de ser dinámico
                                for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
                                {
                                    ICell cell = row.GetCell(cellIndex);
                                    if (cell != null)
                                    {
                                        data[rowIndex, cellIndex] = cell.ToString(); // Obtén el valor de la celda como texto
                                                                        // Ahora puedes hacer lo que quieras con 'cellValue', como mostrarlo en una interfaz de usuario o procesarlo de alguna otra manera
                                    }
                                }
                            }
                        }
                        //TODO: Aca se busca como pintar los datos
                    }
                }
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}