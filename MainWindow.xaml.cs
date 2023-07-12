using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, RecipeInfo> recipeDictionary;

        public MainWindow()
        {
            InitializeComponent();
            
            recipeDictionary = new Dictionary<string, RecipeInfo>()
    {
        {
            "Кукурузная каша на молоке", new RecipeInfo
            {
                Description = "питьевая вода – 500 мл\r\nмолоко – 500 мл\r\nсоль – на кончике ножа\r\nкукурузная крупа – 200 г\r\nсахар – 3 ст. л.\r\nванильный экстракт – 1/2 ч. л.\r\nочищенные грецкие орехи и свежие ягоды для подачи – по вкусу\r\nсливки жирностью 33% – 200 мл\n\n\nКукурузная каша на молоке c ягодами способна оживить меню семейного завтрака, которое обычно, честно говоря, не отличается особым разнообразием. Что вы едите утром? Овсянку, бутерброды, сырники… Мы же предлагаем приготовить на завтрак кукурузную кашу, обладающую чудесным золотистым цветом, которая улучшит настроение всех присутствующих за столом. А значит, день точно будет добрым! К тому же кукурузную кашу мы предлагаем украсить ягодами (подойдут даже замороженные дачные): это дополнит «картину» завтрака яркими красками, вкусами и ароматами.",
                ImagePath = "https://www.gastronom.ru/binfiles/images/20170707/b242f42c.jpg"
            }
        },
        {
            "Закуска из копченого лосося\r\n", new RecipeInfo
            {
                Description = "250 г филе копченого лосося\r\n4 яйца\r\n4 ч. л. каперсов\r\n2 ст. л. лимонного сока\r\n2 ч. л. зерновой сладкой горчицы\r\n3 ст. л. оливкового масла\r\nсвежемолотый черный перец\n\n\nВодку подают охлаждённой до температуры 6-8º. Некоторые любители даже охлаждают в холодильнике водочные рюмки и стопки. Главное — не переусердствовать: чрезмерно охлаждённая водка не доставит никакого удовольствия участникам застолья.\r\n\r\nСейчас водку, как правило, подают в небольших стопочках или рюмках. Каждую стопку водки традиционно пьют до дна.\r\n\r\nВодку обязательно нужно закусывать (в отличие, например, от коньяка или виски). Её закусывают жирными, а также солёными блюдами — салом, борщом, пельменями, квашеной или тушёной капустой, селёдкой, солёными огурцами, заливным или студнем, икрой. А чтобы нейтрализовать «ударяющие в нос» спиртовые пары, водку «занюхивают» — обычно хлебом или солёным огурцом.",
                ImagePath = "https://www.gastronom.ru/binfiles/images/20150319/be884c91.jpg"
            }
        },
        {
            "Шаурма с эринги на гриле", new RecipeInfo
            {
                Description = "600 г грибов эринги\r\n8 зубчиков чеснока, 40 г\r\n100 г растительного масла\r\n1 ч. л. абхазской аджики\r\n1 ч. л. приправы для мяса\r\nсоль\n\n\nШаурмой нынче называют самые разнообразные варианты начинки, завернутой в лепешку – и это вовсе не обязательно должно быть мясо на специальном шампуре. В нашем случае это грибы эринги – впрочем, весьма мясистые! Жаренные на гриле, они становятся хрустящими снаружи и мягкими и сочными внутри – как раз то, что нужно для вкусной шаурмы!",
                ImagePath = "https://www.gastronom.ru/binfiles/images/20230307/b7e6d3e6.jpg"
            }
        }
    };

            recipeListBox.ItemsSource = recipeDictionary.Keys;
        }

        private void recipeListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedRecipe = recipeListBox.SelectedItem as string;
              
                if (!string.IsNullOrEmpty(selectedRecipe) && recipeDictionary.ContainsKey(selectedRecipe))
                {
                    RecipeInfo recipeInfo = recipeDictionary[selectedRecipe];

                    FlowDocument flowDocument = new FlowDocument();

                    flowDocument.Blocks.Add(new Paragraph(new Run(selectedRecipe) { FontWeight = FontWeights.Bold }));

                    flowDocument.Blocks.Add(new Paragraph(new Run(recipeInfo.Description)));
                    
                    if (!string.IsNullOrEmpty(recipeInfo.ImagePath))
                    {
                        Image recipeImage = new Image();
                        recipeImage.Source = new BitmapImage(new Uri(recipeInfo.ImagePath));

                        Viewbox viewbox = new Viewbox();
                        viewbox.Child = recipeImage;

                        flowDocument.Blocks.Add(new BlockUIContainer(viewbox));
                    }
                    
                    recipeDocumentReader.Document = flowDocument;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }


        class RecipeInfo
        {
            public string Description { get; set; }
            public string ImagePath { get; set; }
        }

    }
}