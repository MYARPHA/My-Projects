using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PluginTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Загружает и инициализирует компоненты интерфейса, определенные в XAML-файле
        }

        MediaPlayer mediaPlayer = new(); // Создает новый экземпляр класса MediaPlayer, который используется для воспроизведения аудиофайлов
        string fileName; // Объявляет строковую переменную для хранения пути к выбранному аудиофайлу

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog /* Создается объект OpenFileDialog,
                                                           который предоставляет диалоговое окно для выбора файла*/
            {
                Multiselect = false, // Указывает, что пользователь не может выбрать несколько файлов одновременно                    
                DefaultExt = ".mp3" // По умолчанию будут показаны файлы с расширением .mp3
            };
            bool? dialogOK = fileDialog.ShowDialog(); /*Метод ShowDialog() отображает диалоговое окно и возвращает true, 
                                                      если пользователь выбрал файл и нажал OK, и false в противном случае*/

            if (dialogOK == true) /*Если пользователь выбрал файл (dialogOK == true), то путь к файлу сохраняется в переменной fileName, 
                                   отображается в текстовом поле FileName.Text, 
                                   и медиаплеер открывает этот файл для воспроизведения с помощью метода mediaPlayer.Open(...);*/
            {
                fileName = fileDialog.FileName;
                FileName.Text = fileDialog.FileName;
                mediaPlayer.Open(new Uri(fileName));
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer?.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
                double volumeLevel = (double)e.NewValue / 100; 
                mediaPlayer.Volume = volumeLevel;
        }
    }
}