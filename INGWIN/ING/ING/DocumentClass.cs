using System;
//Псевдоним просранств имём
using word = Microsoft.Office.Interop.Word;
using excel = Microsoft.Office.Interop.Excel;
using System.Data;
using CryptLibraryING;

namespace Sale_App
{
    class Document_Class
    {
        /// <summary>
        /// Список доступных видов отчётов
        /// </summary>
        internal enum Document_Type
        {
            Report, Statistic
        }
        /// <summary>
        /// Итоговый выходной формат отчёта
        /// </summary>
        internal enum Document_Format
        {
            Word, Excel, PDF
        }

        /// <summary>
        /// Метод создания и сохранения документов
        /// в форматах Microsoft Word (doc, PDF),
        /// Excel (exls)
        /// </summary>
        /// <param name="type">Тип создаваемого документа
        /// отчёт или статистика</param>
        /// <param name="format">Формат сохранения 
        /// документ или таблица</param>
        /// <param name="name">Название документа</param>
        /// <param name="table">Входная таблица с данными</param>
        public void Document_Create(Document_Type type,
            Document_Format format, string name,
            DataTable table)
        {
            //Получение данных о конфигурации документа
            Configuration_class configuration_Class
                = new Configuration_class();
            configuration_Class.Document_Configuration_Get();
            //Проверка на пустоту названия
            switch (name != "" || name != null)
            {
                case true:
                    //Выбор формата либо Word либо Excel
                    switch (format)
                    {
                        case Document_Format.Word:
                            //Запуск процесса в дистпечере задач
                            word.Application application
                                = new word.Application();
                            //создание документа в процессе
                            word.Document document
                                //Присвоение документа процессу, Visible: true
                                //возможность редактирования документа
                                = application.Documents.Add(Visible: true);
                            try
                            {
                                //Объявление дипапазона для формирования текста
                                word.Range range = document.Range(0, 0);
                                //89Настройка отступов в документе
                                document.Sections.PageSetup.LeftMargin
                                    = application.CentimetersToPoints(
                                        (float)Configuration_class.
                                        doc_Left_Merge);
                                document.Sections.PageSetup.TopMargin
                                    = application.CentimetersToPoints(
                                        (float)Configuration_class.
                                        doc_Top_Merge);
                                document.Sections.PageSetup.RightMargin
                                    = application.
                                    CentimetersToPoints((float)
                                    Configuration_class.doc_Right_Merge);
                                document.Sections.PageSetup.BottomMargin
                                    = application.CentimetersToPoints(
                                        (float)Configuration_class.
                                        doc_Bottom_Merge);
                                //Присвоение текстового знеачения в дипазон
                                range.Text =
                                    Configuration_class.Organiztion_Name;
                                //Настройка выравнивания текста
                                range.ParagraphFormat.Alignment =
                                    word.WdParagraphAlignment.
                                    wdAlignParagraphCenter;
                                //Настройка интервала после абзаца
                                range.ParagraphFormat.SpaceAfter = 1;
                                //Настройка интервала перед абзаца
                                range.ParagraphFormat.SpaceBefore = 1;
                                //Настройка межстрочного интервала
                                range.ParagraphFormat.LineSpacingRule
                                    = word.WdLineSpacing.wdLineSpaceSingle;
                                //Настройка названия шрифта
                                range.Font.Name = "Times New Roman";
                                //Настройка размера шрифта
                                range.Font.Size = 12;
                                //Добавление параграфов
                                document.Paragraphs.Add();//В конце текста
                                document.Paragraphs.Add();//Свободный
                                document.Paragraphs.Add();//Для будущего текста
                                //Параграф для названия документа
                                word.Paragraph Document_Name
                                    = document.Paragraphs.Add();
                                //Настройка параграфа через свойство диапазона
                                Document_Name.Format.Alignment
                                    = word.WdParagraphAlignment.wdAlignParagraphCenter;
                                Document_Name.Range.Font.Name = "Times New Roman";
                                Document_Name.Range.Font.Size = 16;
                                //Проверка на тип документа, отчёт или статистика
                                switch (type)
                                {
                                    case Document_Type.Report:
                                        Document_Name.Range.Text = "ОТЧЁТ";

                                        break;
                                    case Document_Type.Statistic:
                                        Document_Name.Range.Text = "СТАТИСТИЧЕСКИЙ ОТЧЁТ";
                                        break;
                                }
                                document.Paragraphs.Add();
                                document.Paragraphs.Add();
                                document.Paragraphs.Add();
                                word.Paragraph statparg = document.Paragraphs.Add();
                                //Создание области таблицы в документе
                                word.Table stat_table
                                    //Добавление таблицы в область документа
                                    //Указывается параграф в котором документ создан
                                    //Количество строк и столбцов
                                    = document.Tables.Add(statparg.Range,
                                    table.Rows.Count, table.Columns.Count);
                                //Настройка границ таблицы внутренние 
                                stat_table.Borders.InsideLineStyle
                                    = word.WdLineStyle.wdLineStyleSingle;
                                //Настройка границ таблицы внешние
                                stat_table.Borders.OutsideLineStyle
                                    = word.WdLineStyle.wdLineStyleSingle;
                                //Выравнивание текста внутри ячеек по ширине 
                                stat_table.Rows.Alignment
                                    = word.WdRowAlignment.wdAlignRowCenter;
                                //Выравнивание текста внутри ячеек по высоте
                                stat_table.Range.Cells.VerticalAlignment =
                                    word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                stat_table.Range.Font.Size = 11;
                                stat_table.Range.Font.Name = "Times New Roman";
                                //Индексация столбцов и строк в Word начинается с 1,1
                                for (int row = 1; row <= table.Rows.Count; row++)
                                    for (int col = 1; col <= table.Columns.Count; col++)
                                    {
                                        stat_table.Cell(row, col).Range.Text
                                            = table.Rows[row - 1][col - 1].ToString();
                                    }
                                document.Paragraphs.Add();
                                document.Paragraphs.Add();
                                //Парадграф с фиксациейц даты создания документа
                                word.Paragraph Footparg = document.Paragraphs.Add();
                                Footparg.Range.Text =
                                    string.Format("Дата создания \t\t\t{0}",
                                    DateTime.Now.ToString("dd.MM.yyyy"));
                            }
                            catch (Exception ex)
                            {
                                System.Windows.Forms.MessageBox.Show(ex.Message);
                            }
                            finally
                            {

                                switch (format)
                                {
                                    case Document_Format.Word:
                                        //Сохранение документа с названием из метода,
                                        //и в формате doc
                                        document.SaveAs2(string.Format("{0}\\{1}", Environment.CurrentDirectory, name),
                                            word.WdSaveFormat.wdFormatDocument);
                                        break;
                                    case Document_Format.PDF:
                                        //Сохранение документа в формате PDF
                                        document.SaveAs2(string.Format("{0}\\{1}", Environment.CurrentDirectory, name),
                                            word.WdSaveFormat.wdFormatPDF);
                                        break;
                                }
                                //Закрываем документ
                                document.Close();
                                //Выходим из процесса с его закрытием
                                application.Quit();
                            }
                            break;
                        case Document_Format.Excel:
                            //Создание процесса Excel
                            excel.Application application_ex
                                = new excel.Application();
                            //Создание книги
                            excel.Workbook workbook
                                = application_ex.Workbooks.Add();
                            //Создание страницы
                            excel.Worksheet worksheet
                                = (excel.Worksheet)workbook.ActiveSheet;
                            try
                            {
                                switch (type)
                                {
                                    case Document_Type.Report:
                                        //Название страницы
                                        worksheet.Name = "Отчёт";
                                        for (int row = 0; row < table.Rows.Count; row++)
                                            for (int col = 0; col < table.Columns.Count; col++)
                                            {
                                                //ЗАнесение данных в ячейку
                                                worksheet.Cells[row + 1][col + 1]
                                                    = table.Rows[row][col].ToString();
                                            }
                                        //Указание диапазона работы с ячеёками листа
                                        excel.Range border
                                            //Начало диапазона
                                            = worksheet.Range[worksheet.Cells[1, 1],
                                            //Динамический конец диапазона в зависимости от
                                            //выдодимых данных
                                            worksheet.Cells[table.Rows.Count + 1]
                                            [table.Columns.Count + 1]];
                                        //Стиль линий границ ячеек
                                        border.Borders.LineStyle = excel.XlLineStyle.xlContinuous;
                                        //Выравнивание во высоте
                                        border.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                                        //Выравнивание по ширине
                                        border.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                                        //Внесение даты создания документа
                                        worksheet.Cells[table.Rows.Count + 3][2]
                                            = string.Format("Дата создания {0}",
                                            DateTime.Now.ToString());
                                        //Объединение ячеек
                                        worksheet.Range[worksheet.Cells[table.Rows.Count + 3, 2],
                                            worksheet.Cells[table.Rows.Count + 2,
                                            table.Columns.Count + 2]].Merge();
                                        break;
                                    case Document_Type.Statistic:
                                        worksheet.Name = "Статистический отчёт";
                                        for (int row = 0; row < table.Rows.Count; row++)
                                            for (int col = 0; col < table.Columns.Count; col++)
                                            {
                                                worksheet.Cells[row + 1][col + 1]
                                                    = table.Rows[row][col].ToString();
                                            }
                                        excel.Range border1
                                            = worksheet.Range[worksheet.Cells[1, 1],
                                            worksheet.Cells[table.Rows.Count + 1]
                                            [table.Columns.Count + 1]];
                                        border1.Borders.LineStyle
                                            = excel.XlLineStyle.xlContinuous;
                                        border1.VerticalAlignment
                                            = excel.XlHAlign.xlHAlignCenter;
                                        border1.HorizontalAlignment
                                            = excel.XlHAlign.xlHAlignCenter;
                                        worksheet.Cells[table.Rows.Count + 3][2]
                                            = string.Format("Дата создания {0}",
                                            DateTime.Now.ToString());
                                        worksheet.Range[worksheet.Cells[table.Rows.Count + 3, 2],
                                            worksheet.Cells[table.Rows.Count + 2,
                                            table.Columns.Count + 2]].Merge();
                                        //Класс области графиков
                                        excel.ChartObjects chartObjects
                                            = (excel.ChartObjects)worksheet.ChartObjects(
                                                Type.Missing);
                                        //Область размещения графиков: отступы слева сверху,
                                        //размер ширина и высота
                                        excel.ChartObject chartObject
                                            = chartObjects.Add(300, 50, 250, 250);
                                        //Объявление области графика
                                        excel.Chart chart = chartObject.Chart;
                                        //Объявление колекции построений графиков
                                        excel.SeriesCollection seriesCollection
                                            = (excel.SeriesCollection)chart.SeriesCollection(
                                                Type.Missing);
                                        //Объявление посторения графика
                                        excel.Series series = seriesCollection.NewSeries();
                                        //Тип графика
                                        chart.ChartType = excel.XlChartType.xl3DColumn;
                                        //Диапазон значений по оси X
                                        series.XValues =
                                            worksheet.get_Range("B2", "B" + table.Rows.Count + 1);
                                        //Диапазон значений по оси Y
                                        series.Values =
                                            worksheet.get_Range("C2", "C" + table.Rows.Count + 1);
                                        break;
                                }
                            }
                            catch
                            {

                            }
                            finally
                            {
                                //Сохранение книги
                                workbook.SaveAs(string.Format("{0}\\{1}", Environment.CurrentDirectory, name), application_ex.DefaultSaveFormat);
                                //Закрытие книги
                                workbook.Close();
                                //Завершение процесса
                                application_ex.Quit();
                            }
                            break;
                    }
                    break;
                case false:
                    System.Windows.Forms.MessageBox.Show
                        ("Введите название документп");
                    break;
            }

        }
    }
}

