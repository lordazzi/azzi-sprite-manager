using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;

namespace Azzi_Sprite_Manager
{
    public partial class asm : Form
    {
        PictureBox selection; //definindo a picturebox que vai dizer quem está selecionado
        Bitmap[] sprites = new Bitmap[48]; //Essa Bitmap é referente a transformação de 1 imagem em 48, ela precisa ser publica
        Image pink, void_image;
        public asm()
        {
            InitializeComponent();
            SelectMeView(sprite_view1);
            pink = pink_img.Image; //Imagem que preenche os campos vazios
            void_image = void_img.Image; //Imagem que identifica os campos vazios
        }

        //IMPORTANDO AS IMAGENS LEGAIS ;D
        #region funções relacionadas com a inserção de imagens nas pictureboxes
        //Função que compara duas imagens, para identificar as partes pretas de uma imagem gigante convertida para varias pequenas, as partes pretas viram NULL
        private bool ImageComparision(Image myimg1, Image myimg2)
        {
            string img1_ref, img2_ref;
            int count1 = 0, count2 = 0;
            bool equal = true;
            Bitmap img1 = new Bitmap(myimg1);
            Bitmap img2 = new Bitmap(myimg2);
            if (img1.Width == img2.Width && img1.Height == img2.Height)
            {
                for (int i = 0; i < img1.Width; i++)
                {
                    for (int j = 0; j < img1.Height; j++)
                    {
                        img1_ref = img1.GetPixel(i, j).ToString();
                        img2_ref = img2.GetPixel(i, j).ToString();
                        if (img1_ref != img2_ref)
                        {
                            count2++;
                            equal = false;
                            break;
                        }
                        count1++;
                    }
                }
                return equal;
            }

            else
            {
                return false;
            }
        }

        //Função que coloca as imagens nas PictureBoxes, fazendo as devidas analises
        private void ImageInTheBox(PictureBox pic, string[] paths, int array_index)
        {
            if ((paths.Length) > array_index) //Verificando se o INDEX do Array não o faz extrapolar seu limite
            {
                if (paths[array_index] == "-Internal-Conversion")
                {
                    Image BmpToImg = sprites[array_index] as Image;
                    //ImageComparision está verificando pixel por pixel se as imagens são iguais
                    if (ImageComparision(BmpToImg, void_image))
                    {
                        pic.Image = null;
                    }

                    else
                    {
                        pic.Image = BmpToImg;
                    }
                }

                else if (paths[array_index] != "")
                {
                    if (Image.FromFile(paths[array_index]).Height == 32 && Image.FromFile(paths[array_index]).Height == 32 && Image.FromFile(paths[array_index]).PixelFormat == PixelFormat.Format24bppRgb)
                    {
                        pic.Image = Image.FromFile(paths[array_index]);
                        //pegando o nome da imagem
                        string nome = paths[array_index];
                        while (true)
                        {
                            nome = nome.Substring(nome.IndexOf("\\") + 1);
                            if (nome.IndexOf("\\") == -1)
                            {
                                break;
                            }
                        }
                        pic.Tag = nome;
                    }

                    else
                    {
                        MessageBox.Show("Can't read the sprite: " + paths[array_index] + ".", "Can't read", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            else
            {
                //Retira as imagens inexistentes
                pic.Image = null;
            }
        }

        //Retirando a imagem de uma PictureBox
        private void EraseImage(PictureBox pic)
        {
            pic.Image = null;
        }
        #endregion
        #region Importando as imagens para a matriz de vizualização
        private void button1_Click(object sender, EventArgs e)
        {
            //nova janela de abrir coisas
            OpenFileDialog pasta = new OpenFileDialog();
            pasta.Multiselect = true;
            pasta.Title = "Select your sprites.";
            pasta.Filter = "Tibia Sprite (.bmp)|*.bmp";
            pasta.ShowDialog();

            //Não pode ter arquivo de mais!
            int filesQtd = pasta.FileNames.Length;
            bool breakthis = false;
            if (filesQtd != 0)
            {
                if (filesQtd > 48)
                {
                    MessageBox.Show("Too much files,\n max of 48 sprites.", "48 file limit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    breakthis = true;
                }

                if (breakthis == false)
                {
                    //passando os arquivos para um array mais delicioso
                    string[] view = new string[filesQtd];
                    for (int i = 0; i < filesQtd; i++)
                    {
                        view[i] = pasta.FileNames[i];
                    }

                    //organizador inteligente
                    #region 1x1
                    if (filesQtd <= 12)
                    {
                        //Primeiro quadro
                        EraseImage(sprite_view1);
                        EraseImage(sprite_view2);
                        EraseImage(sprite_view7);
                        ImageInTheBox(sprite_view8, view, 0);

                        //Segundo quadro
                        EraseImage(sprite_view3);
                        EraseImage(sprite_view4);
                        EraseImage(sprite_view9);
                        ImageInTheBox(sprite_view10, view, 1);

                        //Terceiro quadro
                        EraseImage(sprite_view5);
                        EraseImage(sprite_view6);
                        EraseImage(sprite_view11);
                        ImageInTheBox(sprite_view12, view, 2);

                        //Quarto quadro
                        EraseImage(sprite_view13);
                        EraseImage(sprite_view14);
                        EraseImage(sprite_view19);
                        ImageInTheBox(sprite_view20, view, 3);

                        //Quinto quadro
                        EraseImage(sprite_view15);
                        EraseImage(sprite_view16);
                        EraseImage(sprite_view21);
                        ImageInTheBox(sprite_view22, view, 4);

                        //Sexto quadro
                        EraseImage(sprite_view17);
                        EraseImage(sprite_view18);
                        EraseImage(sprite_view23);
                        ImageInTheBox(sprite_view24, view, 5);

                        //Sétimo quadro
                        EraseImage(sprite_view25);
                        EraseImage(sprite_view26);
                        EraseImage(sprite_view31);
                        ImageInTheBox(sprite_view32, view, 6);

                        //Oitavo quadro
                        EraseImage(sprite_view27);
                        EraseImage(sprite_view28);
                        EraseImage(sprite_view33);
                        ImageInTheBox(sprite_view34, view, 7);

                        //Nono quadro
                        EraseImage(sprite_view29);
                        EraseImage(sprite_view30);
                        EraseImage(sprite_view35);
                        ImageInTheBox(sprite_view36, view, 8);

                        //Décimo quadro
                        EraseImage(sprite_view37);
                        EraseImage(sprite_view38);
                        EraseImage(sprite_view43);
                        ImageInTheBox(sprite_view44, view, 9);

                        //Décimo primeiro quadro
                        EraseImage(sprite_view39);
                        EraseImage(sprite_view40);
                        EraseImage(sprite_view45);
                        ImageInTheBox(sprite_view46, view, 10);

                        //Décimo segundo quadro
                        EraseImage(sprite_view41);
                        EraseImage(sprite_view42);
                        EraseImage(sprite_view47);
                        ImageInTheBox(sprite_view48, view, 11);
                    }
                    #endregion
                    #region 2x1
                    else if (filesQtd <= 24) //2x1
                    {
                        //Primeiro quadro
                        EraseImage(sprite_view1);
                        EraseImage(sprite_view2);
                        ImageInTheBox(sprite_view7, view, 0);
                        ImageInTheBox(sprite_view8, view, 1);

                        //Segundo quadro
                        EraseImage(sprite_view3);
                        EraseImage(sprite_view4);
                        ImageInTheBox(sprite_view9, view, 2);
                        ImageInTheBox(sprite_view10, view, 3);

                        //Terceiro quadro
                        EraseImage(sprite_view5);
                        EraseImage(sprite_view6);
                        ImageInTheBox(sprite_view11, view, 4);
                        ImageInTheBox(sprite_view12, view, 5);

                        //Quarto quadro
                        EraseImage(sprite_view13);
                        EraseImage(sprite_view14);
                        ImageInTheBox(sprite_view19, view, 6);
                        ImageInTheBox(sprite_view20, view, 7);

                        //Quinto quadro
                        EraseImage(sprite_view15);
                        EraseImage(sprite_view16);
                        ImageInTheBox(sprite_view21, view, 8);
                        ImageInTheBox(sprite_view22, view, 9);

                        //Sexto quadro
                        EraseImage(sprite_view17);
                        EraseImage(sprite_view18);
                        ImageInTheBox(sprite_view23, view, 10);
                        ImageInTheBox(sprite_view24, view, 11);

                        //Sétimo quadro
                        EraseImage(sprite_view25);
                        ImageInTheBox(sprite_view26, view, 12);
                        EraseImage(sprite_view31);
                        ImageInTheBox(sprite_view32, view, 13);

                        //Oitavo quadro
                        EraseImage(sprite_view27);
                        ImageInTheBox(sprite_view28, view, 14);
                        EraseImage(sprite_view33);
                        ImageInTheBox(sprite_view34, view, 15);

                        //Nono quadro
                        EraseImage(sprite_view29);
                        ImageInTheBox(sprite_view30, view, 16);
                        EraseImage(sprite_view35);
                        ImageInTheBox(sprite_view36, view, 17);

                        //Décimo quadro
                        EraseImage(sprite_view37);
                        ImageInTheBox(sprite_view38, view, 18);
                        EraseImage(sprite_view43);
                        ImageInTheBox(sprite_view44, view, 19);

                        //Décimo primeiro quadro
                        EraseImage(sprite_view39);
                        ImageInTheBox(sprite_view40, view, 20);
                        EraseImage(sprite_view45);
                        ImageInTheBox(sprite_view46, view, 21);

                        //Décimo segundo quadro
                        EraseImage(sprite_view41);
                        ImageInTheBox(sprite_view42, view, 22);
                        EraseImage(sprite_view47);
                        ImageInTheBox(sprite_view48, view, 23);
                    }
                    #endregion
                    #region estilo 3 sprites
                    else if (filesQtd <= 36) //estilo 3 sprites
                    {
                        //Primeiro quadro
                        EraseImage(sprite_view1);
                        ImageInTheBox(sprite_view2, view, 0);
                        ImageInTheBox(sprite_view7, view, 1);
                        ImageInTheBox(sprite_view8, view, 2);

                        //Segundo quadro
                        EraseImage(sprite_view3);
                        ImageInTheBox(sprite_view4, view, 3);
                        ImageInTheBox(sprite_view9, view, 4);
                        ImageInTheBox(sprite_view10, view, 5);

                        //Terceiro quadro
                        EraseImage(sprite_view5);
                        ImageInTheBox(sprite_view6, view, 6);
                        ImageInTheBox(sprite_view11, view, 7);
                        ImageInTheBox(sprite_view12, view, 8);

                        //Quarto quadro
                        EraseImage(sprite_view13);
                        ImageInTheBox(sprite_view14, view, 9);
                        ImageInTheBox(sprite_view19, view, 10);
                        ImageInTheBox(sprite_view20, view, 11);

                        //Quinto quadro
                        EraseImage(sprite_view15);
                        ImageInTheBox(sprite_view16, view, 12);
                        ImageInTheBox(sprite_view21, view, 13);
                        ImageInTheBox(sprite_view22, view, 14);

                        //Sexto quadro
                        EraseImage(sprite_view17);
                        ImageInTheBox(sprite_view18, view, 15);
                        ImageInTheBox(sprite_view23, view, 16);
                        ImageInTheBox(sprite_view24, view, 17);

                        //Sétimo quadro
                        EraseImage(sprite_view25);
                        ImageInTheBox(sprite_view26, view, 18);
                        ImageInTheBox(sprite_view31, view, 19);
                        ImageInTheBox(sprite_view32, view, 20);

                        //Oitavo quadro
                        EraseImage(sprite_view27);
                        ImageInTheBox(sprite_view28, view, 21);
                        ImageInTheBox(sprite_view33, view, 22);
                        ImageInTheBox(sprite_view34, view, 23);

                        //Nono quadro
                        EraseImage(sprite_view29);
                        ImageInTheBox(sprite_view30, view, 24);
                        ImageInTheBox(sprite_view35, view, 25);
                        ImageInTheBox(sprite_view36, view, 26);

                        //Décimo quadro
                        EraseImage(sprite_view37);
                        ImageInTheBox(sprite_view38, view, 27);
                        ImageInTheBox(sprite_view43, view, 28);
                        ImageInTheBox(sprite_view44, view, 29);

                        //Décimo primeiro quadro
                        EraseImage(sprite_view39);
                        ImageInTheBox(sprite_view40, view, 30);
                        ImageInTheBox(sprite_view45, view, 31);
                        ImageInTheBox(sprite_view46, view, 32);

                        //Décimo segundo quadro
                        EraseImage(sprite_view41);
                        ImageInTheBox(sprite_view42, view, 33);
                        ImageInTheBox(sprite_view47, view, 34);
                        ImageInTheBox(sprite_view48, view, 35);
                    }
                    #endregion
                    #region 2x2
                    else if (filesQtd <= 48) //considerando que seja 2x2
                    {
                        //Primeiro quadro
                        ImageInTheBox(sprite_view1, view, 0);
                        ImageInTheBox(sprite_view2, view, 1);
                        ImageInTheBox(sprite_view7, view, 2);
                        ImageInTheBox(sprite_view8, view, 3);

                        //Segundo quadro
                        ImageInTheBox(sprite_view3, view, 4);
                        ImageInTheBox(sprite_view4, view, 5);
                        ImageInTheBox(sprite_view9, view, 6);
                        ImageInTheBox(sprite_view10, view, 7);

                        //Terceiro quadro
                        ImageInTheBox(sprite_view5, view, 8);
                        ImageInTheBox(sprite_view6, view, 9);
                        ImageInTheBox(sprite_view11, view, 10);
                        ImageInTheBox(sprite_view12, view, 11);

                        //Quarto quadro
                        ImageInTheBox(sprite_view13, view, 12);
                        ImageInTheBox(sprite_view14, view, 13);
                        ImageInTheBox(sprite_view19, view, 14);
                        ImageInTheBox(sprite_view20, view, 15);

                        //Quinto quadro
                        ImageInTheBox(sprite_view15, view, 16);
                        ImageInTheBox(sprite_view16, view, 17);
                        ImageInTheBox(sprite_view21, view, 18);
                        ImageInTheBox(sprite_view22, view, 19);

                        //Sexto quadro
                        ImageInTheBox(sprite_view17, view, 20);
                        ImageInTheBox(sprite_view18, view, 21);
                        ImageInTheBox(sprite_view23, view, 22);
                        ImageInTheBox(sprite_view24, view, 23);

                        //Sétimo quadro
                        ImageInTheBox(sprite_view25, view, 24);
                        ImageInTheBox(sprite_view26, view, 25);
                        ImageInTheBox(sprite_view31, view, 26);
                        ImageInTheBox(sprite_view32, view, 27);

                        //Oitavo quadro
                        ImageInTheBox(sprite_view27, view, 28);
                        ImageInTheBox(sprite_view28, view, 29);
                        ImageInTheBox(sprite_view33, view, 30);
                        ImageInTheBox(sprite_view34, view, 31);

                        //Nono quadro
                        ImageInTheBox(sprite_view29, view, 32);
                        ImageInTheBox(sprite_view30, view, 33);
                        ImageInTheBox(sprite_view35, view, 34);
                        ImageInTheBox(sprite_view36, view, 35);

                        //Décimo quadro
                        ImageInTheBox(sprite_view37, view, 36);
                        ImageInTheBox(sprite_view38, view, 37);
                        ImageInTheBox(sprite_view43, view, 38);
                        ImageInTheBox(sprite_view44, view, 39);

                        //Décimo primeiro quadro
                        ImageInTheBox(sprite_view39, view, 40);
                        ImageInTheBox(sprite_view40, view, 41);
                        ImageInTheBox(sprite_view45, view, 42);
                        ImageInTheBox(sprite_view46, view, 43);

                        //Décimo segundo quadro
                        ImageInTheBox(sprite_view41, view, 44);
                        ImageInTheBox(sprite_view42, view, 45);
                        ImageInTheBox(sprite_view47, view, 46);
                        ImageInTheBox(sprite_view48, view, 47);
                    }
                    #endregion
                    #region matriz explicativa
                    /*
                 * MATRIZ DE PICTUREBOX
                 * 
                 * [ 1][ 2]  [ 3][ 4]  [ 5][ 6]
                 * [ 7][ 8]  [ 9][10]  [11][12]
                 * 
                 * [13][14]  [15][16]  [17][18]
                 * [19][20]  [21][22]  [23][24]
                 * 
                 * [25][26]  [27][28]  [29][30]
                 * [31][32]  [33][34]  [35][36]
                 * 
                 * [37][38]  [39][40]  [41][42]
                 * [43][44]  [45][46]  [47][48]
                 */
                    #endregion
                }
            }
        }
        #endregion
        #region Importando as imagens para a matriz de edição
        private void ImportButton_Click(object sender, EventArgs e)
        {
            //nova janela de abrir coisas
            OpenFileDialog pasta = new OpenFileDialog();
            pasta.Multiselect = true;
            pasta.Title = "Select your sprites.";
            pasta.Filter = "Tibia Sprite (.bmp)|*.bmp";
            pasta.ShowDialog();

            //Não pode ter arquivo de mais!
            int filesQtd = pasta.FileNames.Length;
            string[] view = new string[filesQtd];
            bool breakthis = false;
            if (filesQtd != 0)
            {
                #region 1to48
                //Convertendo uma imagem grande para 48 sprites
                if (filesQtd == 1)
                {
                    Image teste = Image.FromFile(pasta.FileName);
                    if (Image.FromFile(pasta.FileName).PixelFormat == PixelFormat.Format24bppRgb && Image.FromFile(pasta.FileName).Width == 192 && Image.FromFile(pasta.FileName).Height == 256)
                    {
                        Bitmap bigimage = Image.FromFile(pasta.FileName) as Bitmap;
                        view = new string[48]; //alterando o tamanho do array, só uma burocracia bonita
                        for (int i = 0; i < 48; i++)
                        {
                            sprites[i] = new Bitmap(32, 32, PixelFormat.Format24bppRgb);
                            view[i] = "-Internal-Conversion";
                            using (Graphics g = Graphics.FromImage(sprites[i]))
                            {
                                int x = 0, y = 0;
                                if (i == 0) { x = 0; y = 0; }
                                else if (i == 1) { x = 32; y = 0; }
                                else if (i == 2) { x = 64; y = 0; }
                                else if (i == 3) { x = 96; y = 0; }
                                else if (i == 4) { x = 128; y = 0; }
                                else if (i == 5) { x = 160; y = 0; }

                                else if (i == 6) { x = 0; y = 32; }
                                else if (i == 7) { x = 32; y = 32; }
                                else if (i == 8) { x = 64; y = 32; }
                                else if (i == 9) { x = 96; y = 32; }
                                else if (i == 10) { x = 128; y = 32; }
                                else if (i == 11) { x = 160; y = 32; }

                                else if (i == 12) { x = 0; y = 64; }
                                else if (i == 13) { x = 32; y = 64; }
                                else if (i == 14) { x = 64; y = 64; }
                                else if (i == 15) { x = 96; y = 64; }
                                else if (i == 16) { x = 128; y = 64; }
                                else if (i == 17) { x = 160; y = 64; }

                                else if (i == 18) { x = 0; y = 96; }
                                else if (i == 19) { x = 32; y = 96; }
                                else if (i == 20) { x = 64; y = 96; }
                                else if (i == 21) { x = 96; y = 96; }
                                else if (i == 22) { x = 128; y = 96; }
                                else if (i == 23) { x = 160; y = 96; }

                                else if (i == 24) { x = 0; y = 128; }
                                else if (i == 25) { x = 32; y = 128; }
                                else if (i == 26) { x = 64; y = 128; }
                                else if (i == 27) { x = 96; y = 128; }
                                else if (i == 28) { x = 128; y = 128; }
                                else if (i == 29) { x = 160; y = 128; }

                                else if (i == 30) { x = 0; y = 160; }
                                else if (i == 31) { x = 32; y = 160; }
                                else if (i == 32) { x = 64; y = 160; }
                                else if (i == 33) { x = 96; y = 160; }
                                else if (i == 34) { x = 128; y = 160; }
                                else if (i == 35) { x = 160; y = 160; }

                                else if (i == 36) { x = 0; y = 192; }
                                else if (i == 37) { x = 32; y = 192; }
                                else if (i == 38) { x = 64; y = 192; }
                                else if (i == 39) { x = 96; y = 192; }
                                else if (i == 40) { x = 128; y = 192; }
                                else if (i == 41) { x = 160; y = 192; }

                                else if (i == 42) { x = 0; y = 224; }
                                else if (i == 43) { x = 32; y = 224; }
                                else if (i == 44) { x = 64; y = 224; }
                                else if (i == 45) { x = 96; y = 224; }
                                else if (i == 46) { x = 128; y = 224; }
                                else if (i == 47) { x = 160; y = 224; }

                                g.DrawImage(bigimage, new Rectangle(0, 0, 32, 32), new Rectangle(x, y, 32, 32), GraphicsUnit.Pixel);
                                filesQtd = 50; //Como esse número de sprites é impossivel, o organizador inteligente vai  entrar no modo de organização de sprites especial (converção de 1 para 48)
                            }
                        }
                    }
                }
                #endregion
                else if (filesQtd > 48)
                {
                    MessageBox.Show("Too much files,\n max of 48 sprites.", "48 file limit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    breakthis = true;
                }

                if (breakthis == false)
                {
                    //passando os arquivos para um array mais delicioso
                    int ForLimit;

                    /* A variavel filesQts pode ter até o valor de 50 files, mas isso só acontece
                     * quando um arquivo grande é importado, então ele recebe 50 para que o organizador
                     * inteligente do programa entenda que se trata de uma ocasião especial, como não é
                     * possivel se carregar 50 arquivos, o filesQtd deve ser substituido pelo ForLimit,
                     * caso contrario, pode estourar o limite do array
                     */
                    if (filesQtd == 50) { ForLimit = 48; }
                    else { ForLimit = filesQtd; }

                    for (int i = 0; i < ForLimit; i++)
                    {
                        if (view[i] == null)
                        {
                            view[i] = pasta.FileNames[i];
                        }
                    }

                    //organizador inteligente
                    #region 1x1
                    if (filesQtd <= 12)
                    {
                        //Primeiro quadro
                        EraseImage(sprite_edit1);
                        EraseImage(sprite_edit2);
                        EraseImage(sprite_edit7);
                        ImageInTheBox(sprite_edit8, view, 0);

                        //Segundo quadro
                        EraseImage(sprite_edit3);
                        EraseImage(sprite_edit4);
                        EraseImage(sprite_edit9);
                        ImageInTheBox(sprite_edit10, view, 1);

                        //Terceiro quadro
                        EraseImage(sprite_edit5);
                        EraseImage(sprite_edit6);
                        EraseImage(sprite_edit11);
                        ImageInTheBox(sprite_edit12, view, 2);

                        //Quarto quadro
                        EraseImage(sprite_edit13);
                        EraseImage(sprite_edit14);
                        EraseImage(sprite_edit19);
                        ImageInTheBox(sprite_edit20, view, 3);

                        //Quinto quadro
                        EraseImage(sprite_edit15);
                        EraseImage(sprite_edit16);
                        EraseImage(sprite_edit21);
                        ImageInTheBox(sprite_edit22, view, 4);

                        //Sexto quadro
                        EraseImage(sprite_edit17);
                        EraseImage(sprite_edit18);
                        EraseImage(sprite_edit23);
                        ImageInTheBox(sprite_edit24, view, 5);

                        //Sétimo quadro
                        EraseImage(sprite_edit25);
                        EraseImage(sprite_edit26);
                        EraseImage(sprite_edit31);
                        ImageInTheBox(sprite_edit32, view, 6);

                        //Oitavo quadro
                        EraseImage(sprite_edit27);
                        EraseImage(sprite_edit28);
                        EraseImage(sprite_edit33);
                        ImageInTheBox(sprite_edit34, view, 7);

                        //Nono quadro
                        EraseImage(sprite_edit29);
                        EraseImage(sprite_edit30);
                        EraseImage(sprite_edit35);
                        ImageInTheBox(sprite_edit36, view, 8);

                        //Décimo quadro
                        EraseImage(sprite_edit37);
                        EraseImage(sprite_edit38);
                        EraseImage(sprite_edit43);
                        ImageInTheBox(sprite_edit44, view, 9);

                        //Décimo primeiro quadro
                        EraseImage(sprite_edit39);
                        EraseImage(sprite_edit40);
                        EraseImage(sprite_edit45);
                        ImageInTheBox(sprite_edit46, view, 10);

                        //Décimo segundo quadro
                        EraseImage(sprite_edit41);
                        EraseImage(sprite_edit42);
                        EraseImage(sprite_edit47);
                        ImageInTheBox(sprite_edit48, view, 11);
                    }
                    #endregion
                    #region 2x1
                    else if (filesQtd <= 24) //2x1
                    {
                        //Primeiro quadro
                        EraseImage(sprite_edit1);
                        EraseImage(sprite_edit2);
                        ImageInTheBox(sprite_edit7, view, 0);
                        ImageInTheBox(sprite_edit8, view, 1);

                        //Segundo quadro
                        EraseImage(sprite_edit3);
                        EraseImage(sprite_edit4);
                        ImageInTheBox(sprite_edit9, view, 2);
                        ImageInTheBox(sprite_edit10, view, 3);

                        //Terceiro quadro
                        EraseImage(sprite_edit5);
                        EraseImage(sprite_edit6);
                        ImageInTheBox(sprite_edit11, view, 4);
                        ImageInTheBox(sprite_edit12, view, 5);

                        //Quarto quadro
                        EraseImage(sprite_edit13);
                        EraseImage(sprite_edit14);
                        ImageInTheBox(sprite_edit19, view, 6);
                        ImageInTheBox(sprite_edit20, view, 7);

                        //Quinto quadro
                        EraseImage(sprite_edit15);
                        EraseImage(sprite_edit16);
                        ImageInTheBox(sprite_edit21, view, 8);
                        ImageInTheBox(sprite_edit22, view, 9);

                        //Sexto quadro
                        EraseImage(sprite_edit17);
                        EraseImage(sprite_edit18);
                        ImageInTheBox(sprite_edit23, view, 10);
                        ImageInTheBox(sprite_edit24, view, 11);

                        //Sétimo quadro
                        EraseImage(sprite_edit25);
                        ImageInTheBox(sprite_edit26, view, 12);
                        EraseImage(sprite_edit31);
                        ImageInTheBox(sprite_edit32, view, 13);

                        //Oitavo quadro
                        EraseImage(sprite_edit27);
                        ImageInTheBox(sprite_edit28, view, 14);
                        EraseImage(sprite_edit33);
                        ImageInTheBox(sprite_edit34, view, 15);

                        //Nono quadro
                        EraseImage(sprite_edit29);
                        ImageInTheBox(sprite_edit30, view, 16);
                        EraseImage(sprite_edit35);
                        ImageInTheBox(sprite_edit36, view, 17);

                        //Décimo quadro
                        EraseImage(sprite_edit37);
                        ImageInTheBox(sprite_edit38, view, 18);
                        EraseImage(sprite_edit43);
                        ImageInTheBox(sprite_edit44, view, 19);

                        //Décimo primeiro quadro
                        EraseImage(sprite_edit39);
                        ImageInTheBox(sprite_edit40, view, 20);
                        EraseImage(sprite_edit45);
                        ImageInTheBox(sprite_edit46, view, 21);

                        //Décimo segundo quadro
                        EraseImage(sprite_edit41);
                        ImageInTheBox(sprite_edit42, view, 22);
                        EraseImage(sprite_edit47);
                        ImageInTheBox(sprite_edit48, view, 23);
                    }
                    #endregion
                    #region estilo 3 sprites
                    else if (filesQtd <= 36) //estilo 3 sprites
                    {
                        //Primeiro quadro
                        EraseImage(sprite_edit1);
                        ImageInTheBox(sprite_edit2, view, 0);
                        ImageInTheBox(sprite_edit7, view, 1);
                        ImageInTheBox(sprite_edit8, view, 2);

                        //Segundo quadro
                        EraseImage(sprite_edit3);
                        ImageInTheBox(sprite_edit4, view, 3);
                        ImageInTheBox(sprite_edit9, view, 4);
                        ImageInTheBox(sprite_edit10, view, 5);

                        //Terceiro quadro
                        EraseImage(sprite_edit5);
                        ImageInTheBox(sprite_edit6, view, 6);
                        ImageInTheBox(sprite_edit11, view, 7);
                        ImageInTheBox(sprite_edit12, view, 8);

                        //Quarto quadro
                        EraseImage(sprite_edit13);
                        ImageInTheBox(sprite_edit14, view, 9);
                        ImageInTheBox(sprite_edit19, view, 10);
                        ImageInTheBox(sprite_edit20, view, 11);

                        //Quinto quadro
                        EraseImage(sprite_edit15);
                        ImageInTheBox(sprite_edit16, view, 12);
                        ImageInTheBox(sprite_edit21, view, 13);
                        ImageInTheBox(sprite_edit22, view, 14);

                        //Sexto quadro
                        EraseImage(sprite_edit17);
                        ImageInTheBox(sprite_edit18, view, 15);
                        ImageInTheBox(sprite_edit23, view, 16);
                        ImageInTheBox(sprite_edit24, view, 17);

                        //Sétimo quadro
                        EraseImage(sprite_edit25);
                        ImageInTheBox(sprite_edit26, view, 18);
                        ImageInTheBox(sprite_edit31, view, 19);
                        ImageInTheBox(sprite_edit32, view, 20);

                        //Oitavo quadro
                        EraseImage(sprite_edit27);
                        ImageInTheBox(sprite_edit28, view, 21);
                        ImageInTheBox(sprite_edit33, view, 22);
                        ImageInTheBox(sprite_edit34, view, 23);

                        //Nono quadro
                        EraseImage(sprite_edit29);
                        ImageInTheBox(sprite_edit30, view, 24);
                        ImageInTheBox(sprite_edit35, view, 25);
                        ImageInTheBox(sprite_edit36, view, 26);

                        //Décimo quadro
                        EraseImage(sprite_edit37);
                        ImageInTheBox(sprite_edit38, view, 27);
                        ImageInTheBox(sprite_edit43, view, 28);
                        ImageInTheBox(sprite_edit44, view, 29);

                        //Décimo primeiro quadro
                        EraseImage(sprite_edit39);
                        ImageInTheBox(sprite_edit40, view, 30);
                        ImageInTheBox(sprite_edit45, view, 31);
                        ImageInTheBox(sprite_edit46, view, 32);

                        //Décimo segundo quadro
                        EraseImage(sprite_edit41);
                        ImageInTheBox(sprite_edit42, view, 33);
                        ImageInTheBox(sprite_edit47, view, 34);
                        ImageInTheBox(sprite_edit48, view, 35);
                    }
                    #endregion
                    #region 2x2
                    else if (filesQtd <= 48) //considerando que seja 2x2
                    {
                        //Primeiro quadro
                        ImageInTheBox(sprite_edit1, view, 0);
                        ImageInTheBox(sprite_edit2, view, 1);
                        ImageInTheBox(sprite_edit7, view, 2);
                        ImageInTheBox(sprite_edit8, view, 3);

                        //Segundo quadro
                        ImageInTheBox(sprite_edit3, view, 4);
                        ImageInTheBox(sprite_edit4, view, 5);
                        ImageInTheBox(sprite_edit9, view, 6);
                        ImageInTheBox(sprite_edit10, view, 7);

                        //Terceiro quadro
                        ImageInTheBox(sprite_edit5, view, 8);
                        ImageInTheBox(sprite_edit6, view, 9);
                        ImageInTheBox(sprite_edit11, view, 10);
                        ImageInTheBox(sprite_edit12, view, 11);

                        //Quarto quadro
                        ImageInTheBox(sprite_edit13, view, 12);
                        ImageInTheBox(sprite_edit14, view, 13);
                        ImageInTheBox(sprite_edit19, view, 14);
                        ImageInTheBox(sprite_edit20, view, 15);

                        //Quinto quadro
                        ImageInTheBox(sprite_edit15, view, 16);
                        ImageInTheBox(sprite_edit16, view, 17);
                        ImageInTheBox(sprite_edit21, view, 18);
                        ImageInTheBox(sprite_edit22, view, 19);

                        //Sexto quadro
                        ImageInTheBox(sprite_edit17, view, 20);
                        ImageInTheBox(sprite_edit18, view, 21);
                        ImageInTheBox(sprite_edit23, view, 22);
                        ImageInTheBox(sprite_edit24, view, 23);

                        //Sétimo quadro
                        ImageInTheBox(sprite_edit25, view, 24);
                        ImageInTheBox(sprite_edit26, view, 25);
                        ImageInTheBox(sprite_edit31, view, 26);
                        ImageInTheBox(sprite_edit32, view, 27);

                        //Oitavo quadro
                        ImageInTheBox(sprite_edit27, view, 28);
                        ImageInTheBox(sprite_edit28, view, 29);
                        ImageInTheBox(sprite_edit33, view, 30);
                        ImageInTheBox(sprite_edit34, view, 31);

                        //Nono quadro
                        ImageInTheBox(sprite_edit29, view, 32);
                        ImageInTheBox(sprite_edit30, view, 33);
                        ImageInTheBox(sprite_edit35, view, 34);
                        ImageInTheBox(sprite_edit36, view, 35);

                        //Décimo quadro
                        ImageInTheBox(sprite_edit37, view, 36);
                        ImageInTheBox(sprite_edit38, view, 37);
                        ImageInTheBox(sprite_edit43, view, 38);
                        ImageInTheBox(sprite_edit44, view, 39);

                        //Décimo primeiro quadro
                        ImageInTheBox(sprite_edit39, view, 40);
                        ImageInTheBox(sprite_edit40, view, 41);
                        ImageInTheBox(sprite_edit45, view, 42);
                        ImageInTheBox(sprite_edit46, view, 43);

                        //Décimo segundo quadro
                        ImageInTheBox(sprite_edit41, view, 44);
                        ImageInTheBox(sprite_edit42, view, 45);
                        ImageInTheBox(sprite_edit47, view, 46);
                        ImageInTheBox(sprite_edit48, view, 47);
                    }
                    #endregion
                    #region Exceção para converção de 1 sprite grande para 48
                    else // Quando se refere a uma imagem grande importada e dividida em 48
                    {
                        ImageInTheBox(sprite_edit1, view, 0);
                        ImageInTheBox(sprite_edit2, view, 1);
                        ImageInTheBox(sprite_edit3, view, 2);
                        ImageInTheBox(sprite_edit4, view, 3);
                        ImageInTheBox(sprite_edit5, view, 4);
                        ImageInTheBox(sprite_edit6, view, 5);
                        ImageInTheBox(sprite_edit7, view, 6);
                        ImageInTheBox(sprite_edit8, view, 7);
                        ImageInTheBox(sprite_edit9, view, 8);
                        ImageInTheBox(sprite_edit10, view, 9);
                        ImageInTheBox(sprite_edit11, view, 10);
                        ImageInTheBox(sprite_edit12, view, 11);
                        ImageInTheBox(sprite_edit13, view, 12);
                        ImageInTheBox(sprite_edit14, view, 13);
                        ImageInTheBox(sprite_edit15, view, 14);
                        ImageInTheBox(sprite_edit16, view, 15);
                        ImageInTheBox(sprite_edit17, view, 16);
                        ImageInTheBox(sprite_edit18, view, 17);
                        ImageInTheBox(sprite_edit19, view, 18);
                        ImageInTheBox(sprite_edit20, view, 19);
                        ImageInTheBox(sprite_edit21, view, 20);
                        ImageInTheBox(sprite_edit22, view, 21);
                        ImageInTheBox(sprite_edit23, view, 22);
                        ImageInTheBox(sprite_edit24, view, 23);
                        ImageInTheBox(sprite_edit25, view, 24);
                        ImageInTheBox(sprite_edit26, view, 25);
                        ImageInTheBox(sprite_edit27, view, 26);
                        ImageInTheBox(sprite_edit28, view, 27);
                        ImageInTheBox(sprite_edit29, view, 28);
                        ImageInTheBox(sprite_edit30, view, 29);
                        ImageInTheBox(sprite_edit31, view, 30);
                        ImageInTheBox(sprite_edit32, view, 31);
                        ImageInTheBox(sprite_edit33, view, 32);
                        ImageInTheBox(sprite_edit34, view, 33);
                        ImageInTheBox(sprite_edit35, view, 34);
                        ImageInTheBox(sprite_edit36, view, 35);
                        ImageInTheBox(sprite_edit37, view, 36);
                        ImageInTheBox(sprite_edit38, view, 37);
                        ImageInTheBox(sprite_edit39, view, 38);
                        ImageInTheBox(sprite_edit40, view, 39);
                        ImageInTheBox(sprite_edit41, view, 40);
                        ImageInTheBox(sprite_edit42, view, 41);
                        ImageInTheBox(sprite_edit43, view, 42);
                        ImageInTheBox(sprite_edit44, view, 43);
                        ImageInTheBox(sprite_edit45, view, 44);
                        ImageInTheBox(sprite_edit46, view, 45);
                        ImageInTheBox(sprite_edit47, view, 46);
                        ImageInTheBox(sprite_edit48, view, 47);
                    }
                    #endregion
                    #region matriz explicativa
                    /*
                 * MATRIZ DE PICTUREBOX
                 * 
                 * [ 1][ 2]  [ 3][ 4]  [ 5][ 6]
                 * [ 7][ 8]  [ 9][10]  [11][12]
                 * 
                 * [13][14]  [15][16]  [17][18]
                 * [19][20]  [21][22]  [23][24]
                 * 
                 * [25][26]  [27][28]  [29][30]
                 * [31][32]  [33][34]  [35][36]
                 * 
                 * [37][38]  [39][40]  [41][42]
                 * [43][44]  [45][46]  [47][48]
                 */
                    #endregion
                }
            }
        }
        #endregion

        //SELECIONANDO AS IMAGENS COM O QUADRADINHO AMARELO BONITO
        #region funções relacionadas com a seleção das pictureboxes que contém as sprites
        public void SelectMeView(PictureBox pic)
        {
            selection = pic;
            int my_x = pic.Location.X - 1, my_y = pic.Location.Y - 1;
            Selection_View.Location = new Point(my_x, my_y);
            Selection_View.Visible = true;
            Selection_Edit.Visible = false;
            pic.BringToFront();
        }

        public void SelectMeEdit(PictureBox pic)
        {
            selection = pic;
            int my_x = pic.Location.X - 1, my_y = pic.Location.Y - 1;
            Selection_Edit.Location = new Point(my_x, my_y);
            Selection_Edit.Visible = true;
            Selection_View.Visible = false;
            pic.BringToFront();
        }
        #endregion
        #region SelectMeView - Seleção da parte de vizualização
        private void sprite_view1_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view1);
        }

        private void sprite_view2_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view2);
        }

        private void sprite_view3_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view3);
        }

        private void sprite_view4_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view4);
        }

        private void sprite_view5_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view5);
        }

        private void sprite_view6_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view6);
        }

        private void sprite_view7_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view7);
        }

        private void sprite_view8_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view8);
        }

        private void sprite_view9_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view9);
        }

        private void sprite_view10_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view10);
        }

        private void sprite_view11_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view11);
        }

        private void sprite_view12_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view12);
        }

        private void sprite_view13_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view13);
        }

        private void sprite_view14_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view14);
        }

        private void sprite_view15_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view15);
        }

        private void sprite_view16_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view16);
        }

        private void sprite_view17_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view17);
        }

        private void sprite_view18_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view18);
        }

        private void sprite_view19_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view19);
        }

        private void sprite_view20_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view20);
        }

        private void sprite_view21_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view21);
        }

        private void sprite_view22_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view22);
        }

        private void sprite_view23_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view23);
        }

        private void sprite_view24_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view24);
        }

        private void sprite_view25_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view25);
        }

        private void sprite_view26_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view26);
        }

        private void sprite_view27_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view27);
        }

        private void sprite_view28_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view28);
        }

        private void sprite_view29_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view29);
        }

        private void sprite_view30_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view30);
        }

        private void sprite_view31_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view31);
        }

        private void sprite_view32_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view32);
        }

        private void sprite_view33_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view33);
        }

        private void sprite_view34_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view34);
        }

        private void sprite_view35_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view35);
        }

        private void sprite_view36_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view36);
        }

        private void sprite_view37_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view37);
        }

        private void sprite_view38_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view38);
        }

        private void sprite_view39_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view39);
        }

        private void sprite_view40_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view40);
        }

        private void sprite_view41_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view41);
        }

        private void sprite_view42_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view42);
        }

        private void sprite_view43_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view43);
        }

        private void sprite_view44_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view44);
        }

        private void sprite_view45_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view45);
        }

        private void sprite_view46_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view46);
        }

        private void sprite_view47_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view47);
        }

        private void sprite_view48_Click(object sender, EventArgs e)
        {
            SelectMeView(sprite_view48);
        }
        #endregion
        #region SelectMeEdit - Seleção da parte de edição
        private void sprite_edit1_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit1);
        }

        private void sprite_edit2_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit2);
        }

        private void sprite_edit3_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit3);
        }

        private void sprite_edit4_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit4);
        }

        private void sprite_edit5_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit5);
        }

        private void sprite_edit6_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit6);
        }

        private void sprite_edit7_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit7);
        }

        private void sprite_edit8_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit8);
        }

        private void sprite_edit9_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit9);
        }

        private void sprite_edit10_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit10);
        }

        private void sprite_edit11_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit11);
        }

        private void sprite_edit12_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit12);
        }

        private void sprite_edit13_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit13);
        }

        private void sprite_edit14_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit14);
        }

        private void sprite_edit15_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit15);
        }

        private void sprite_edit16_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit16);
        }

        private void sprite_edit17_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit17);
        }

        private void sprite_edit18_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit18);
        }

        private void sprite_edit19_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit19);
        }

        private void sprite_edit20_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit20);
        }

        private void sprite_edit21_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit21);
        }

        private void sprite_edit22_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit22);
        }

        private void sprite_edit23_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit23);
        }

        private void sprite_edit24_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit24);
        }

        private void sprite_edit25_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit25);
        }

        private void sprite_edit26_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit26);
        }

        private void sprite_edit27_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit27);
        }

        private void sprite_edit28_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit28);
        }

        private void sprite_edit29_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit29);
        }

        private void sprite_edit30_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit30);
        }

        private void sprite_edit31_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit31);
        }

        private void sprite_edit32_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit32);
        }

        private void sprite_edit33_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit33);
        }

        private void sprite_edit34_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit34);
        }

        private void sprite_edit35_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit35);
        }

        private void sprite_edit36_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit36);
        }

        private void sprite_edit37_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit37);
        }

        private void sprite_edit38_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit38);
        }

        private void sprite_edit39_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit39);
        }

        private void sprite_edit40_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit40);
        }

        private void sprite_edit41_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit41);
        }

        private void sprite_edit42_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit42);
        }

        private void sprite_edit43_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit43);
        }

        private void sprite_edit44_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit44);
        }

        private void sprite_edit45_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit45);
        }

        private void sprite_edit46_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit46);
        }

        private void sprite_edit47_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit47);
        }

        private void sprite_edit48_Click(object sender, EventArgs e)
        {
            SelectMeEdit(sprite_edit48);
        }
        #endregion

        //FAZENDO A ANIMAÇÃO MTO LINDA
        #region Variaveis e Funções referente a parte de animação
        //Variaveis publicas para o ticker
        int direction_view = 0, pos_view = 0, direction_edit = 0, pos_edit = 0; //são as variaveis que entendem para que lado o monstro está olhando e a posição dele
        bool[] quadros_view = new bool[12], quadros_edit = new bool[12];

        //Função responsável por indicar qual dos conjuntos de picturebox estão aptos para serem exibidos na animação
        private void getAnimationParam(PictureBox pic1, PictureBox pic2, PictureBox pic3, PictureBox pic4, int quadros_index, int type)
        {
            if (pic1.Image != null || pic2.Image != null || pic3.Image != null || pic4.Image != null)
            {
                if (type == 1)
                {
                    quadros_view[quadros_index] = true;
                }

                else
                {
                    quadros_edit[quadros_index] = true;
                }
            }

            else
            {
                if (type == 1)
                {
                    quadros_view[quadros_index] = false;
                }

                else
                {
                    quadros_edit[quadros_index] = false;
                }
            }
        }

        //Colocando a animação no objeto de animação
        private void setAnimation(PictureBox pic1, PictureBox pic2, PictureBox pic3, PictureBox pic4, int type)
        {
            if (type == 1)
            {
                anima_view1.Image = pic1.Image;
                anima_view2.Image = pic2.Image;
                anima_view3.Image = pic3.Image;
                anima_view4.Image = pic4.Image;
            }

            else
            {
                anima_edit1.Image = pic1.Image;
                anima_edit2.Image = pic2.Image;
                anima_edit3.Image = pic3.Image;
                anima_edit4.Image = pic4.Image;
            }
        }

        //Função que retira as imagens do objeto de animação
        private void eraseAnimation(int type)
        {
            if (type == 1)
            {
                anima_view1.Image = null;
                anima_view2.Image = null;
                anima_view3.Image = null;
                anima_view4.Image = null;
            }

            else
            {
                anima_edit1.Image = null;
                anima_edit2.Image = null;
                anima_edit3.Image = null;
                anima_edit4.Image = null;
            }
        }

        //função responsável por substituir as Sprites não cobertas do EDIT por sprites do VIEW
        private PictureBox IfNull(PictureBox pic_edit, PictureBox pic_view)
        {
            if (pic_edit.Image == null)
            {
                return pic_view;
            }

            else
            {
                return pic_edit;
            }
        }

        #endregion
        #region exercendo a animação
        private void animation_Tick(object sender, EventArgs e)
        {
            bool animationCompleted_view = false, animationCompleted_edit = false;
            //Verificando quais quadros tem imagens para exercer a animação
            getAnimationParam(sprite_view1, sprite_view2, sprite_view7, sprite_view8, 0, 1);
            getAnimationParam(sprite_view3, sprite_view4, sprite_view9, sprite_view10, 1, 1);
            getAnimationParam(sprite_view5, sprite_view6, sprite_view11, sprite_view12, 2, 1);
            getAnimationParam(sprite_view13, sprite_view14, sprite_view19, sprite_view20, 3, 1);
            getAnimationParam(sprite_view15, sprite_view16, sprite_view21, sprite_view22, 4, 1);
            getAnimationParam(sprite_view17, sprite_view18, sprite_view23, sprite_view24, 5, 1);
            getAnimationParam(sprite_view25, sprite_view26, sprite_view31, sprite_view32, 6, 1);
            getAnimationParam(sprite_view27, sprite_view28, sprite_view33, sprite_view34, 7, 1);
            getAnimationParam(sprite_view29, sprite_view30, sprite_view35, sprite_view36, 8, 1);
            getAnimationParam(sprite_view37, sprite_view38, sprite_view43, sprite_view44, 9, 1);
            getAnimationParam(sprite_view39, sprite_view40, sprite_view45, sprite_view46, 10, 1);
            getAnimationParam(sprite_view41, sprite_view42, sprite_view47, sprite_view48, 11, 1);

            getAnimationParam(sprite_edit1, sprite_edit2, sprite_edit7, sprite_edit8, 0, 2);
            getAnimationParam(sprite_edit3, sprite_edit4, sprite_edit9, sprite_edit10, 1, 2);
            getAnimationParam(sprite_edit5, sprite_edit6, sprite_edit11, sprite_edit12, 2, 2);
            getAnimationParam(sprite_edit13, sprite_edit14, sprite_edit19, sprite_edit20, 3, 2);
            getAnimationParam(sprite_edit15, sprite_edit16, sprite_edit21, sprite_edit22, 4, 2);
            getAnimationParam(sprite_edit17, sprite_edit18, sprite_edit23, sprite_edit24, 5, 2);
            getAnimationParam(sprite_edit25, sprite_edit26, sprite_edit31, sprite_edit32, 6, 2);
            getAnimationParam(sprite_edit27, sprite_edit28, sprite_edit33, sprite_edit34, 7, 2);
            getAnimationParam(sprite_edit29, sprite_edit30, sprite_edit35, sprite_edit36, 8, 2);
            getAnimationParam(sprite_edit37, sprite_edit38, sprite_edit43, sprite_edit44, 9, 2);
            getAnimationParam(sprite_edit39, sprite_edit40, sprite_edit45, sprite_edit46, 10, 2);
            getAnimationParam(sprite_edit41, sprite_edit42, sprite_edit47, sprite_edit48, 11, 2);

            #region animação do VIEW
            //ANIMAÇÃO DO VIEW
            if ((pos_view == 0 || pos_view == 2) && animationCompleted_view == false)
            {
                if ((quadros_view[0] == true && direction_view == 0) || (quadros_view[3] == true && direction_view == 1) || (quadros_view[6] == true && direction_view == 2) || (quadros_view[9] == true && direction_view == 3))
                {
                    if (direction_view == 0) { setAnimation(sprite_view1, sprite_view2, sprite_view7, sprite_view8, 1); }
                    else if (direction_view == 1) { setAnimation(sprite_view13, sprite_view14, sprite_view19, sprite_view20, 1); }
                    else if (direction_view == 2) { setAnimation(sprite_view25, sprite_view26, sprite_view31, sprite_view32, 1); }
                    else if (direction_view == 3) { setAnimation(sprite_view37, sprite_view38, sprite_view43, sprite_view44, 1); }
                    animationCompleted_view = true; //Com isso ele só ira começar uma nova animação quando der outro Tick
                }

                else
                {
                    eraseAnimation(1);
                }
                pos_view++;//Próxima posição
            }

            if (pos_view == 1 && animationCompleted_view == false)
            {
                if ((quadros_view[1] == true && direction_view == 0) || (quadros_view[4] == true && direction_view == 1) || (quadros_view[7] == true && direction_view == 2) || (quadros_view[10] == true && direction_view == 3))
                {
                    if (direction_view == 0) { setAnimation(sprite_view3, sprite_view4, sprite_view9, sprite_view10, 1); }
                    else if (direction_view == 1) { setAnimation(sprite_view15, sprite_view16, sprite_view21, sprite_view22, 1); }
                    else if (direction_view == 2) { setAnimation(sprite_view27, sprite_view28, sprite_view33, sprite_view34, 1); }
                    else if (direction_view == 3) { setAnimation(sprite_view39, sprite_view40, sprite_view45, sprite_view46, 1); }
                    animationCompleted_view = true;
                }

                else
                {
                    eraseAnimation(1);
                }
                pos_view++;
            }

            if (pos_view == 3 && animationCompleted_view == false)
            {
                if ((quadros_view[2] == true && direction_view == 0) || (quadros_view[5] == true && direction_view == 1) || (quadros_view[8] == true && direction_view == 2) || (quadros_view[11] == true && direction_view == 3))
                {
                    if (direction_view == 0) { setAnimation(sprite_view5, sprite_view6, sprite_view11, sprite_view12, 1); }
                    else if (direction_view == 1) { setAnimation(sprite_view17, sprite_view18, sprite_view23, sprite_view24, 1); }
                    else if (direction_view == 2) { setAnimation(sprite_view29, sprite_view30, sprite_view35, sprite_view36, 1); }
                    else if (direction_view == 3) { setAnimation(sprite_view41, sprite_view42, sprite_view47, sprite_view48, 1); }
                    animationCompleted_view = true;
                }

                else
                {
                    eraseAnimation(1);
                }

                //Na ultima animada ele passa para a próxima direção
                pos_view = 0;
            }

            #endregion
            #region animação do EDIT
            if ((pos_edit == 0 || pos_edit == 2) && animationCompleted_edit == false)
            {
                if ((quadros_edit[0] == true && direction_edit == 0) || (quadros_edit[3] == true && direction_edit == 1) || (quadros_edit[6] == true && direction_edit == 2) || (quadros_edit[9] == true && direction_edit == 3))
                {
                    if      (direction_edit == 0) { setAnimation(IfNull(sprite_edit1, sprite_view1), IfNull(sprite_edit2, sprite_view2), IfNull(sprite_edit7, sprite_view7), IfNull(sprite_edit8, sprite_view8), 2); }
                    else if (direction_edit == 1) { setAnimation(IfNull(sprite_edit13, sprite_view13), IfNull(sprite_edit14, sprite_view14), IfNull(sprite_edit19, sprite_view19), IfNull(sprite_edit20, sprite_view20), 2); }
                    else if (direction_edit == 2) { setAnimation(IfNull(sprite_edit25, sprite_view25), IfNull(sprite_edit26, sprite_view26), IfNull(sprite_edit31, sprite_view31), IfNull(sprite_edit32, sprite_view32), 2); }
                    else if (direction_edit == 3) { setAnimation(IfNull(sprite_edit37, sprite_view37), IfNull(sprite_edit38, sprite_view38), IfNull(sprite_edit43, sprite_view43), IfNull(sprite_edit44, sprite_view44), 2); }
                    animationCompleted_edit = true; //Com isso ele só ira começar uma nova animação quando der outro Tick
                }

                else if ((quadros_view[0] == true && direction_view == 0) || (quadros_view[3] == true && direction_view == 1) || (quadros_view[6] == true && direction_view == 2) || (quadros_view[9] == true && direction_view == 3))
                {
                    if      (direction_view == 0) { setAnimation(sprite_view1, sprite_view2, sprite_view7, sprite_view8, 1); }
                    else if (direction_view == 1) { setAnimation(sprite_view13, sprite_view14, sprite_view19, sprite_view20, 1); }
                    else if (direction_view == 2) { setAnimation(sprite_view25, sprite_view26, sprite_view31, sprite_view32, 1); }
                    else if (direction_view == 3) { setAnimation(sprite_view37, sprite_view38, sprite_view43, sprite_view44, 1); }
                    animationCompleted_view = true; //Com isso ele só ira começar uma nova animação quando der outro Tick
                }

                else
                {
                    eraseAnimation(2);
                }
                pos_edit++;//Próxima posição
            }

            if (pos_edit == 1 && animationCompleted_edit == false)
            {
                if ((quadros_edit[1] == true && direction_edit == 0) || (quadros_edit[4] == true && direction_edit == 1) || (quadros_edit[7] == true && direction_edit == 2) || (quadros_edit[10] == true && direction_edit == 3))
                {
                    if      (direction_edit == 0) { setAnimation(IfNull(sprite_edit3, sprite_view3), IfNull(sprite_edit4, sprite_view4), IfNull(sprite_edit9, sprite_view9), IfNull(sprite_edit10, sprite_view10), 2); }
                    else if (direction_edit == 1) { setAnimation(IfNull(sprite_edit15, sprite_view15), IfNull(sprite_edit16, sprite_view16), IfNull(sprite_edit21, sprite_view21), IfNull(sprite_edit22, sprite_view22), 2); }
                    else if (direction_edit == 2) { setAnimation(IfNull(sprite_edit27, sprite_view27), IfNull(sprite_edit28, sprite_view28), IfNull(sprite_edit33, sprite_view33), IfNull(sprite_edit34, sprite_view34), 2); }
                    else if (direction_edit == 3) { setAnimation(IfNull(sprite_edit39, sprite_view39), IfNull(sprite_edit40, sprite_view40), IfNull(sprite_edit45, sprite_view45), IfNull(sprite_edit46, sprite_view46), 2); }
                    animationCompleted_edit = true;
                }

                else if ((quadros_view[1] == true && direction_view == 0) || (quadros_view[4] == true && direction_view == 1) || (quadros_view[7] == true && direction_view == 2) || (quadros_view[10] == true && direction_view == 3))
                {
                    if      (direction_view == 0) { setAnimation(sprite_view3, sprite_view4, sprite_view9, sprite_view10, 1); }
                    else if (direction_view == 1) { setAnimation(sprite_view15, sprite_view16, sprite_view21, sprite_view22, 1); }
                    else if (direction_view == 2) { setAnimation(sprite_view27, sprite_view28, sprite_view33, sprite_view34, 1); }
                    else if (direction_view == 3) { setAnimation(sprite_view39, sprite_view40, sprite_view45, sprite_view46, 1); }
                    animationCompleted_view = true;
                }

                else
                {
                    eraseAnimation(2);
                }
                pos_edit++;
            }

            if (pos_edit == 3 && animationCompleted_edit == false)
            {
                if ((quadros_edit[2] == true && direction_edit == 0) || (quadros_edit[5] == true && direction_edit == 1) || (quadros_edit[8] == true && direction_edit == 2) || (quadros_edit[11] == true && direction_edit == 3))
                {
                    if      (direction_edit == 0) { setAnimation(IfNull(sprite_edit5, sprite_view5), IfNull(sprite_edit6, sprite_view6), IfNull(sprite_edit11, sprite_view11), IfNull(sprite_edit12, sprite_view12), 2); }
                    else if (direction_edit == 1) { setAnimation(IfNull(sprite_edit17, sprite_view17), IfNull(sprite_edit18, sprite_view18), IfNull(sprite_edit23, sprite_view23), IfNull(sprite_edit24, sprite_view24), 2); }
                    else if (direction_edit == 2) { setAnimation(IfNull(sprite_edit29, sprite_view29), IfNull(sprite_edit30, sprite_view30), IfNull(sprite_edit35, sprite_view35), IfNull(sprite_edit36, sprite_view36), 2); }
                    else if (direction_edit == 3) { setAnimation(IfNull(sprite_edit41, sprite_view41), IfNull(sprite_edit42, sprite_view42), IfNull(sprite_edit47, sprite_view47), IfNull(sprite_edit48, sprite_view48), 2); }
                    animationCompleted_edit = true;
                }

                else if ((quadros_view[2] == true && direction_view == 0) || (quadros_view[5] == true && direction_view == 1) || (quadros_view[8] == true && direction_view == 2) || (quadros_view[11] == true && direction_view == 3))
                {
                    if (direction_view == 0) { setAnimation(sprite_view5, sprite_view6, sprite_view11, sprite_view12, 1); }
                    else if (direction_view == 1) { setAnimation(sprite_view17, sprite_view18, sprite_view23, sprite_view24, 1); }
                    else if (direction_view == 2) { setAnimation(sprite_view29, sprite_view30, sprite_view35, sprite_view36, 1); }
                    else if (direction_view == 3) { setAnimation(sprite_view41, sprite_view42, sprite_view47, sprite_view48, 1); }
                    animationCompleted_view = true;
                }

                else
                {
                    eraseAnimation(2);
                }

                //Na ultima animada ele passa para a próxima direção
                pos_edit = 0;
            }
            #endregion
        }
        #endregion
        #region atividade dos botões que alteram a direção para qual a animação está olhando
        private void anima_view_left_Click(object sender, EventArgs e)
        {
            if (direction_view == 0)
            {
                direction_view = 3;
            }

            else if (direction_view == 1)
            {
                direction_view = 2;
            }

            else if (direction_view == 2)
            {
                direction_view = 0;
            }

            else if (direction_view == 3)
            {
                direction_view = 1;
            }
        }

        private void anima_view_right_Click(object sender, EventArgs e)
        {
            if (direction_view == 0)
            {
                direction_view = 2;
            }

            else if (direction_view == 1)
            {
                direction_view = 3;
            }

            else if (direction_view == 2)
            {
                direction_view = 1;
            }

            else if (direction_view == 3)
            {
                direction_view = 0;
            }
        }

        private void anima_edit_left_Click(object sender, EventArgs e)
        {
            if (direction_edit == 0)
            {
                direction_edit = 3;
            }

            else if (direction_edit == 1)
            {
                direction_edit = 2;
            }

            else if (direction_edit == 2)
            {
                direction_edit = 0;
            }

            else if (direction_edit == 3)
            {
                direction_edit = 1;
            }
        }

        private void anima_edit_right_Click(object sender, EventArgs e)
        {
            if (direction_edit == 0)
            {
                direction_edit = 2;
            }

            else if (direction_edit == 1)
            {
                direction_edit = 3;
            }

            else if (direction_edit == 2)
            {
                direction_edit = 1;
            }

            else if (direction_edit == 3)
            {
                direction_edit = 0;
            }
        }
        #endregion
        #region matriz explicativa
        /*
         * MATRIZ DE PICTUREBOX
         * [ 1][ 2]  [ 3][ 4]  [ 5][ 6]
         * [ 7][ 8]  [ 9][10]  [11][12]
         * 
         * [13][14]  [15][16]  [17][18]
         * [19][20]  [21][22]  [23][24]
         * 
         * [25][26]  [27][28]  [29][30]
         * [31][32]  [33][34]  [35][36]
         * 
         * [37][38]  [39][40]  [41][42]
         * [43][44]  [45][46]  [47][48]
         * 
         * MATRIZ SIMPLES
         * [ 0] [ 1] [ 2]
         * [ 3] [ 4] [ 5]
         * [ 6] [ 7] [ 8]
         * [ 9] [10] [11]
         * 
         */
        #endregion

        //MOVIMENTANDO AS SPRITES E OS BLOCOS DE SPRITES
        #region Movendo as sprites de um canto pra outra
        //achei que ia ser dificil programar essa parte da bagaça, mas foi facin: só fazer uma função delicia, aplicar em todos 4x e já era ;D
        private void MoveSprite(PictureBox pic, int type)
        {
            PictureBox tmp_pic = new PictureBox();
            tmp_pic.Image = selection.Image;
            tmp_pic.Tag = selection.Tag;

            selection.Image = pic.Image;
            selection.Tag = pic.Tag;

            pic.Image = tmp_pic.Image;
            pic.Tag = tmp_pic.Tag;

            //View
            if (type == 1)
            {
                SelectMeView(pic);
            }

            //Edit
            else if (type == 2)
            {
                SelectMeEdit(pic);
            }
        }

        private void sprite_left_Click(object sender, EventArgs e)
        {
            //VIEW
            if      (selection.Name == "sprite_view1") { MoveSprite(sprite_view6, 1); }
            else if (selection.Name == "sprite_view2") { MoveSprite(sprite_view1, 1); }
            else if (selection.Name == "sprite_view3") { MoveSprite(sprite_view2, 1); }
            else if (selection.Name == "sprite_view4") { MoveSprite(sprite_view3, 1); }
            else if (selection.Name == "sprite_view5") { MoveSprite(sprite_view4, 1); }
            else if (selection.Name == "sprite_view6") { MoveSprite(sprite_view5, 1); }

            else if (selection.Name == "sprite_view7") { MoveSprite(sprite_view12, 1); }
            else if (selection.Name == "sprite_view8") { MoveSprite(sprite_view7, 1); }
            else if (selection.Name == "sprite_view9") { MoveSprite(sprite_view8, 1); }
            else if (selection.Name == "sprite_view10") { MoveSprite(sprite_view9, 1); }
            else if (selection.Name == "sprite_view11") { MoveSprite(sprite_view10, 1); }
            else if (selection.Name == "sprite_view12") { MoveSprite(sprite_view11, 1); }

            else if (selection.Name == "sprite_view13") { MoveSprite(sprite_view18, 1); }
            else if (selection.Name == "sprite_view14") { MoveSprite(sprite_view13, 1); }
            else if (selection.Name == "sprite_view15") { MoveSprite(sprite_view14, 1); }
            else if (selection.Name == "sprite_view16") { MoveSprite(sprite_view15, 1); }
            else if (selection.Name == "sprite_view17") { MoveSprite(sprite_view16, 1); }
            else if (selection.Name == "sprite_view18") { MoveSprite(sprite_view17, 1); }

            else if (selection.Name == "sprite_view19") { MoveSprite(sprite_view24, 1); }
            else if (selection.Name == "sprite_view20") { MoveSprite(sprite_view19, 1); }
            else if (selection.Name == "sprite_view21") { MoveSprite(sprite_view20, 1); }
            else if (selection.Name == "sprite_view22") { MoveSprite(sprite_view21, 1); }
            else if (selection.Name == "sprite_view23") { MoveSprite(sprite_view22, 1); }
            else if (selection.Name == "sprite_view24") { MoveSprite(sprite_view23, 1); }

            else if (selection.Name == "sprite_view25") { MoveSprite(sprite_view30, 1); }
            else if (selection.Name == "sprite_view26") { MoveSprite(sprite_view25, 1); }
            else if (selection.Name == "sprite_view27") { MoveSprite(sprite_view26, 1); }
            else if (selection.Name == "sprite_view28") { MoveSprite(sprite_view27, 1); }
            else if (selection.Name == "sprite_view29") { MoveSprite(sprite_view28, 1); }
            else if (selection.Name == "sprite_view30") { MoveSprite(sprite_view29, 1); }

            else if (selection.Name == "sprite_view31") { MoveSprite(sprite_view36, 1); }
            else if (selection.Name == "sprite_view32") { MoveSprite(sprite_view31, 1); }
            else if (selection.Name == "sprite_view33") { MoveSprite(sprite_view32, 1); }
            else if (selection.Name == "sprite_view34") { MoveSprite(sprite_view33, 1); }
            else if (selection.Name == "sprite_view35") { MoveSprite(sprite_view34, 1); }
            else if (selection.Name == "sprite_view36") { MoveSprite(sprite_view35, 1); }

            else if (selection.Name == "sprite_view37") { MoveSprite(sprite_view42, 1); }
            else if (selection.Name == "sprite_view38") { MoveSprite(sprite_view37, 1); }
            else if (selection.Name == "sprite_view39") { MoveSprite(sprite_view38, 1); }
            else if (selection.Name == "sprite_view40") { MoveSprite(sprite_view39, 1); }
            else if (selection.Name == "sprite_view41") { MoveSprite(sprite_view40, 1); }
            else if (selection.Name == "sprite_view42") { MoveSprite(sprite_view41, 1); }

            else if (selection.Name == "sprite_view43") { MoveSprite(sprite_view48, 1); }
            else if (selection.Name == "sprite_view44") { MoveSprite(sprite_view43, 1); }
            else if (selection.Name == "sprite_view45") { MoveSprite(sprite_view44, 1); }
            else if (selection.Name == "sprite_view46") { MoveSprite(sprite_view45, 1); }
            else if (selection.Name == "sprite_view47") { MoveSprite(sprite_view46, 1); }
            else if (selection.Name == "sprite_view48") { MoveSprite(sprite_view47, 1); }

            //EDIT
            else if (selection.Name == "sprite_edit1") { MoveSprite(sprite_edit6, 2); }
            else if (selection.Name == "sprite_edit2") { MoveSprite(sprite_edit1, 2); }
            else if (selection.Name == "sprite_edit3") { MoveSprite(sprite_edit2, 2); }
            else if (selection.Name == "sprite_edit4") { MoveSprite(sprite_edit3, 2); }
            else if (selection.Name == "sprite_edit5") { MoveSprite(sprite_edit4, 2); }
            else if (selection.Name == "sprite_edit6") { MoveSprite(sprite_edit5, 2); }

            else if (selection.Name == "sprite_edit7") { MoveSprite(sprite_edit12, 2); }
            else if (selection.Name == "sprite_edit8") { MoveSprite(sprite_edit7, 2); }
            else if (selection.Name == "sprite_edit9") { MoveSprite(sprite_edit8, 2); }
            else if (selection.Name == "sprite_edit10") { MoveSprite(sprite_edit9, 2); }
            else if (selection.Name == "sprite_edit11") { MoveSprite(sprite_edit10, 2); }
            else if (selection.Name == "sprite_edit12") { MoveSprite(sprite_edit11, 2); }

            else if (selection.Name == "sprite_edit13") { MoveSprite(sprite_edit18, 2); }
            else if (selection.Name == "sprite_edit14") { MoveSprite(sprite_edit13, 2); }
            else if (selection.Name == "sprite_edit15") { MoveSprite(sprite_edit14, 2); }
            else if (selection.Name == "sprite_edit16") { MoveSprite(sprite_edit15, 2); }
            else if (selection.Name == "sprite_edit17") { MoveSprite(sprite_edit16, 2); }
            else if (selection.Name == "sprite_edit18") { MoveSprite(sprite_edit17, 2); }

            else if (selection.Name == "sprite_edit19") { MoveSprite(sprite_edit24, 2); }
            else if (selection.Name == "sprite_edit20") { MoveSprite(sprite_edit19, 2); }
            else if (selection.Name == "sprite_edit21") { MoveSprite(sprite_edit20, 2); }
            else if (selection.Name == "sprite_edit22") { MoveSprite(sprite_edit21, 2); }
            else if (selection.Name == "sprite_edit23") { MoveSprite(sprite_edit22, 2); }
            else if (selection.Name == "sprite_edit24") { MoveSprite(sprite_edit23, 2); }

            else if (selection.Name == "sprite_edit25") { MoveSprite(sprite_edit30, 2); }
            else if (selection.Name == "sprite_edit26") { MoveSprite(sprite_edit25, 2); }
            else if (selection.Name == "sprite_edit27") { MoveSprite(sprite_edit26, 2); }
            else if (selection.Name == "sprite_edit28") { MoveSprite(sprite_edit27, 2); }
            else if (selection.Name == "sprite_edit29") { MoveSprite(sprite_edit28, 2); }
            else if (selection.Name == "sprite_edit30") { MoveSprite(sprite_edit29, 2); }

            else if (selection.Name == "sprite_edit31") { MoveSprite(sprite_edit36, 2); }
            else if (selection.Name == "sprite_edit32") { MoveSprite(sprite_edit31, 2); }
            else if (selection.Name == "sprite_edit33") { MoveSprite(sprite_edit32, 2); }
            else if (selection.Name == "sprite_edit34") { MoveSprite(sprite_edit33, 2); }
            else if (selection.Name == "sprite_edit35") { MoveSprite(sprite_edit34, 2); }
            else if (selection.Name == "sprite_edit36") { MoveSprite(sprite_edit35, 2); }

            else if (selection.Name == "sprite_edit37") { MoveSprite(sprite_edit42, 2); }
            else if (selection.Name == "sprite_edit38") { MoveSprite(sprite_edit37, 2); }
            else if (selection.Name == "sprite_edit39") { MoveSprite(sprite_edit38, 2); }
            else if (selection.Name == "sprite_edit40") { MoveSprite(sprite_edit39, 2); }
            else if (selection.Name == "sprite_edit41") { MoveSprite(sprite_edit40, 2); }
            else if (selection.Name == "sprite_edit42") { MoveSprite(sprite_edit41, 2); }

            else if (selection.Name == "sprite_edit43") { MoveSprite(sprite_edit48, 2); }
            else if (selection.Name == "sprite_edit44") { MoveSprite(sprite_edit43, 2); }
            else if (selection.Name == "sprite_edit45") { MoveSprite(sprite_edit44, 2); }
            else if (selection.Name == "sprite_edit46") { MoveSprite(sprite_edit45, 2); }
            else if (selection.Name == "sprite_edit47") { MoveSprite(sprite_edit46, 2); }
            else if (selection.Name == "sprite_edit48") { MoveSprite(sprite_edit47, 2); }
        }

        private void sprite_up_Click(object sender, EventArgs e)
        {
            //VIEW
            if      (selection.Name == "sprite_view1") { MoveSprite(sprite_view43, 1); }
            else if (selection.Name == "sprite_view2") { MoveSprite(sprite_view44, 1); }
            else if (selection.Name == "sprite_view3") { MoveSprite(sprite_view45, 1); }
            else if (selection.Name == "sprite_view4") { MoveSprite(sprite_view46, 1); }
            else if (selection.Name == "sprite_view5") { MoveSprite(sprite_view47, 1); }
            else if (selection.Name == "sprite_view6") { MoveSprite(sprite_view48, 1); }

            else if (selection.Name == "sprite_view7") { MoveSprite(sprite_view1, 1); }
            else if (selection.Name == "sprite_view8") { MoveSprite(sprite_view2, 1); }
            else if (selection.Name == "sprite_view9") { MoveSprite(sprite_view3, 1); }
            else if (selection.Name == "sprite_view10") { MoveSprite(sprite_view4, 1); }
            else if (selection.Name == "sprite_view11") { MoveSprite(sprite_view5, 1); }
            else if (selection.Name == "sprite_view12") { MoveSprite(sprite_view6, 1); }

            else if (selection.Name == "sprite_view13") { MoveSprite(sprite_view7, 1); }
            else if (selection.Name == "sprite_view14") { MoveSprite(sprite_view8, 1); }
            else if (selection.Name == "sprite_view15") { MoveSprite(sprite_view9, 1); }
            else if (selection.Name == "sprite_view16") { MoveSprite(sprite_view10, 1); }
            else if (selection.Name == "sprite_view17") { MoveSprite(sprite_view11, 1); }
            else if (selection.Name == "sprite_view18") { MoveSprite(sprite_view12, 1); }

            else if (selection.Name == "sprite_view19") { MoveSprite(sprite_view13, 1); }
            else if (selection.Name == "sprite_view20") { MoveSprite(sprite_view14, 1); }
            else if (selection.Name == "sprite_view21") { MoveSprite(sprite_view15, 1); }
            else if (selection.Name == "sprite_view22") { MoveSprite(sprite_view16, 1); }
            else if (selection.Name == "sprite_view23") { MoveSprite(sprite_view17, 1); }
            else if (selection.Name == "sprite_view24") { MoveSprite(sprite_view18, 1); }

            else if (selection.Name == "sprite_view25") { MoveSprite(sprite_view19, 1); }
            else if (selection.Name == "sprite_view26") { MoveSprite(sprite_view20, 1); }
            else if (selection.Name == "sprite_view27") { MoveSprite(sprite_view21, 1); }
            else if (selection.Name == "sprite_view28") { MoveSprite(sprite_view22, 1); }
            else if (selection.Name == "sprite_view29") { MoveSprite(sprite_view23, 1); }
            else if (selection.Name == "sprite_view30") { MoveSprite(sprite_view24, 1); }

            else if (selection.Name == "sprite_view31") { MoveSprite(sprite_view25, 1); }
            else if (selection.Name == "sprite_view32") { MoveSprite(sprite_view26, 1); }
            else if (selection.Name == "sprite_view33") { MoveSprite(sprite_view27, 1); }
            else if (selection.Name == "sprite_view34") { MoveSprite(sprite_view28, 1); }
            else if (selection.Name == "sprite_view35") { MoveSprite(sprite_view29, 1); }
            else if (selection.Name == "sprite_view36") { MoveSprite(sprite_view30, 1); }

            else if (selection.Name == "sprite_view37") { MoveSprite(sprite_view31, 1); }
            else if (selection.Name == "sprite_view38") { MoveSprite(sprite_view32, 1); }
            else if (selection.Name == "sprite_view39") { MoveSprite(sprite_view33, 1); }
            else if (selection.Name == "sprite_view40") { MoveSprite(sprite_view34, 1); }
            else if (selection.Name == "sprite_view41") { MoveSprite(sprite_view35, 1); }
            else if (selection.Name == "sprite_view42") { MoveSprite(sprite_view36, 1); }

            else if (selection.Name == "sprite_view43") { MoveSprite(sprite_view37, 1); }
            else if (selection.Name == "sprite_view44") { MoveSprite(sprite_view38, 1); }
            else if (selection.Name == "sprite_view45") { MoveSprite(sprite_view39, 1); }
            else if (selection.Name == "sprite_view46") { MoveSprite(sprite_view40, 1); }
            else if (selection.Name == "sprite_view47") { MoveSprite(sprite_view41, 1); }
            else if (selection.Name == "sprite_view48") { MoveSprite(sprite_view42, 1); }

            //EDIT
            else if (selection.Name == "sprite_edit1") { MoveSprite(sprite_edit43, 2); }
            else if (selection.Name == "sprite_edit2") { MoveSprite(sprite_edit44, 2); }
            else if (selection.Name == "sprite_edit3") { MoveSprite(sprite_edit45, 2); }
            else if (selection.Name == "sprite_edit4") { MoveSprite(sprite_edit46, 2); }
            else if (selection.Name == "sprite_edit5") { MoveSprite(sprite_edit47, 2); }
            else if (selection.Name == "sprite_edit6") { MoveSprite(sprite_edit48, 2); }

            else if (selection.Name == "sprite_edit7") { MoveSprite(sprite_edit1, 2); }
            else if (selection.Name == "sprite_edit8") { MoveSprite(sprite_edit2, 2); }
            else if (selection.Name == "sprite_edit9") { MoveSprite(sprite_edit3, 2); }
            else if (selection.Name == "sprite_edit10") { MoveSprite(sprite_edit4, 2); }
            else if (selection.Name == "sprite_edit11") { MoveSprite(sprite_edit5, 2); }
            else if (selection.Name == "sprite_edit12") { MoveSprite(sprite_edit6, 2); }

            else if (selection.Name == "sprite_edit13") { MoveSprite(sprite_edit7, 2); }
            else if (selection.Name == "sprite_edit14") { MoveSprite(sprite_edit8, 2); }
            else if (selection.Name == "sprite_edit15") { MoveSprite(sprite_edit9, 2); }
            else if (selection.Name == "sprite_edit16") { MoveSprite(sprite_edit10, 2); }
            else if (selection.Name == "sprite_edit17") { MoveSprite(sprite_edit11, 2); }
            else if (selection.Name == "sprite_edit18") { MoveSprite(sprite_edit12, 2); }

            else if (selection.Name == "sprite_edit19") { MoveSprite(sprite_edit13, 2); }
            else if (selection.Name == "sprite_edit20") { MoveSprite(sprite_edit14, 2); }
            else if (selection.Name == "sprite_edit21") { MoveSprite(sprite_edit15, 2); }
            else if (selection.Name == "sprite_edit22") { MoveSprite(sprite_edit16, 2); }
            else if (selection.Name == "sprite_edit23") { MoveSprite(sprite_edit17, 2); }
            else if (selection.Name == "sprite_edit24") { MoveSprite(sprite_edit18, 2); }

            else if (selection.Name == "sprite_edit25") { MoveSprite(sprite_edit19, 2); }
            else if (selection.Name == "sprite_edit26") { MoveSprite(sprite_edit20, 2); }
            else if (selection.Name == "sprite_edit27") { MoveSprite(sprite_edit21, 2); }
            else if (selection.Name == "sprite_edit28") { MoveSprite(sprite_edit22, 2); }
            else if (selection.Name == "sprite_edit29") { MoveSprite(sprite_edit23, 2); }
            else if (selection.Name == "sprite_edit30") { MoveSprite(sprite_edit24, 2); }

            else if (selection.Name == "sprite_edit31") { MoveSprite(sprite_edit25, 2); }
            else if (selection.Name == "sprite_edit32") { MoveSprite(sprite_edit26, 2); }
            else if (selection.Name == "sprite_edit33") { MoveSprite(sprite_edit27, 2); }
            else if (selection.Name == "sprite_edit34") { MoveSprite(sprite_edit28, 2); }
            else if (selection.Name == "sprite_edit35") { MoveSprite(sprite_edit29, 2); }
            else if (selection.Name == "sprite_edit36") { MoveSprite(sprite_edit30, 2); }

            else if (selection.Name == "sprite_edit37") { MoveSprite(sprite_edit31, 2); }
            else if (selection.Name == "sprite_edit38") { MoveSprite(sprite_edit32, 2); }
            else if (selection.Name == "sprite_edit39") { MoveSprite(sprite_edit33, 2); }
            else if (selection.Name == "sprite_edit40") { MoveSprite(sprite_edit34, 2); }
            else if (selection.Name == "sprite_edit41") { MoveSprite(sprite_edit35, 2); }
            else if (selection.Name == "sprite_edit42") { MoveSprite(sprite_edit36, 2); }

            else if (selection.Name == "sprite_edit43") { MoveSprite(sprite_edit37, 2); }
            else if (selection.Name == "sprite_edit44") { MoveSprite(sprite_edit38, 2); }
            else if (selection.Name == "sprite_edit45") { MoveSprite(sprite_edit39, 2); }
            else if (selection.Name == "sprite_edit46") { MoveSprite(sprite_edit40, 2); }
            else if (selection.Name == "sprite_edit47") { MoveSprite(sprite_edit41, 2); }
            else if (selection.Name == "sprite_edit48") { MoveSprite(sprite_edit42, 2); }
        }

        private void sprite_right_Click(object sender, EventArgs e)
        {
            //VIEW
            if (selection.Name == "sprite_view1") { MoveSprite(sprite_view2, 1); }
            else if (selection.Name == "sprite_view2") { MoveSprite(sprite_view3, 1); }
            else if (selection.Name == "sprite_view3") { MoveSprite(sprite_view4, 1); }
            else if (selection.Name == "sprite_view4") { MoveSprite(sprite_view5, 1); }
            else if (selection.Name == "sprite_view5") { MoveSprite(sprite_view6, 1); }
            else if (selection.Name == "sprite_view6") { MoveSprite(sprite_view1, 1); }

            else if (selection.Name == "sprite_view7") { MoveSprite(sprite_view8, 1); }
            else if (selection.Name == "sprite_view8") { MoveSprite(sprite_view9, 1); }
            else if (selection.Name == "sprite_view9") { MoveSprite(sprite_view10, 1); }
            else if (selection.Name == "sprite_view10") { MoveSprite(sprite_view11, 1); }
            else if (selection.Name == "sprite_view11") { MoveSprite(sprite_view12, 1); }
            else if (selection.Name == "sprite_view12") { MoveSprite(sprite_view7, 1); }

            else if (selection.Name == "sprite_view13") { MoveSprite(sprite_view14, 1); }
            else if (selection.Name == "sprite_view14") { MoveSprite(sprite_view15, 1); }
            else if (selection.Name == "sprite_view15") { MoveSprite(sprite_view16, 1); }
            else if (selection.Name == "sprite_view16") { MoveSprite(sprite_view17, 1); }
            else if (selection.Name == "sprite_view17") { MoveSprite(sprite_view18, 1); }
            else if (selection.Name == "sprite_view18") { MoveSprite(sprite_view13, 1); }

            else if (selection.Name == "sprite_view19") { MoveSprite(sprite_view20, 1); }
            else if (selection.Name == "sprite_view20") { MoveSprite(sprite_view21, 1); }
            else if (selection.Name == "sprite_view21") { MoveSprite(sprite_view22, 1); }
            else if (selection.Name == "sprite_view22") { MoveSprite(sprite_view23, 1); }
            else if (selection.Name == "sprite_view23") { MoveSprite(sprite_view24, 1); }
            else if (selection.Name == "sprite_view24") { MoveSprite(sprite_view19, 1); }

            else if (selection.Name == "sprite_view25") { MoveSprite(sprite_view26, 1); }
            else if (selection.Name == "sprite_view26") { MoveSprite(sprite_view27, 1); }
            else if (selection.Name == "sprite_view27") { MoveSprite(sprite_view28, 1); }
            else if (selection.Name == "sprite_view28") { MoveSprite(sprite_view29, 1); }
            else if (selection.Name == "sprite_view29") { MoveSprite(sprite_view30, 1); }
            else if (selection.Name == "sprite_view30") { MoveSprite(sprite_view25, 1); }

            else if (selection.Name == "sprite_view31") { MoveSprite(sprite_view32, 1); }
            else if (selection.Name == "sprite_view32") { MoveSprite(sprite_view33, 1); }
            else if (selection.Name == "sprite_view33") { MoveSprite(sprite_view34, 1); }
            else if (selection.Name == "sprite_view34") { MoveSprite(sprite_view35, 1); }
            else if (selection.Name == "sprite_view35") { MoveSprite(sprite_view36, 1); }
            else if (selection.Name == "sprite_view36") { MoveSprite(sprite_view31, 1); }

            else if (selection.Name == "sprite_view37") { MoveSprite(sprite_view38, 1); }
            else if (selection.Name == "sprite_view38") { MoveSprite(sprite_view39, 1); }
            else if (selection.Name == "sprite_view39") { MoveSprite(sprite_view40, 1); }
            else if (selection.Name == "sprite_view40") { MoveSprite(sprite_view41, 1); }
            else if (selection.Name == "sprite_view41") { MoveSprite(sprite_view42, 1); }
            else if (selection.Name == "sprite_view42") { MoveSprite(sprite_view37, 1); }

            else if (selection.Name == "sprite_view43") { MoveSprite(sprite_view44, 1); }
            else if (selection.Name == "sprite_view44") { MoveSprite(sprite_view45, 1); }
            else if (selection.Name == "sprite_view45") { MoveSprite(sprite_view46, 1); }
            else if (selection.Name == "sprite_view46") { MoveSprite(sprite_view47, 1); }
            else if (selection.Name == "sprite_view47") { MoveSprite(sprite_view48, 1); }
            else if (selection.Name == "sprite_view48") { MoveSprite(sprite_view43, 1); }

            //EDIT
            else if (selection.Name == "sprite_edit1") { MoveSprite(sprite_edit2, 2); }
            else if (selection.Name == "sprite_edit2") { MoveSprite(sprite_edit3, 2); }
            else if (selection.Name == "sprite_edit3") { MoveSprite(sprite_edit4, 2); }
            else if (selection.Name == "sprite_edit4") { MoveSprite(sprite_edit5, 2); }
            else if (selection.Name == "sprite_edit5") { MoveSprite(sprite_edit6, 2); }
            else if (selection.Name == "sprite_edit6") { MoveSprite(sprite_edit1, 2); }

            else if (selection.Name == "sprite_edit7") { MoveSprite(sprite_edit8, 2); }
            else if (selection.Name == "sprite_edit8") { MoveSprite(sprite_edit9, 2); }
            else if (selection.Name == "sprite_edit9") { MoveSprite(sprite_edit10, 2); }
            else if (selection.Name == "sprite_edit10") { MoveSprite(sprite_edit11, 2); }
            else if (selection.Name == "sprite_edit11") { MoveSprite(sprite_edit12, 2); }
            else if (selection.Name == "sprite_edit12") { MoveSprite(sprite_edit7, 2); }

            else if (selection.Name == "sprite_edit13") { MoveSprite(sprite_edit14, 2); }
            else if (selection.Name == "sprite_edit14") { MoveSprite(sprite_edit15, 2); }
            else if (selection.Name == "sprite_edit15") { MoveSprite(sprite_edit16, 2); }
            else if (selection.Name == "sprite_edit16") { MoveSprite(sprite_edit17, 2); }
            else if (selection.Name == "sprite_edit17") { MoveSprite(sprite_edit18, 2); }
            else if (selection.Name == "sprite_edit18") { MoveSprite(sprite_edit13, 2); }

            else if (selection.Name == "sprite_edit19") { MoveSprite(sprite_edit20, 2); }
            else if (selection.Name == "sprite_edit20") { MoveSprite(sprite_edit21, 2); }
            else if (selection.Name == "sprite_edit21") { MoveSprite(sprite_edit22, 2); }
            else if (selection.Name == "sprite_edit22") { MoveSprite(sprite_edit23, 2); }
            else if (selection.Name == "sprite_edit23") { MoveSprite(sprite_edit24, 2); }
            else if (selection.Name == "sprite_edit24") { MoveSprite(sprite_edit19, 2); }

            else if (selection.Name == "sprite_edit25") { MoveSprite(sprite_edit26, 2); }
            else if (selection.Name == "sprite_edit26") { MoveSprite(sprite_edit27, 2); }
            else if (selection.Name == "sprite_edit27") { MoveSprite(sprite_edit28, 2); }
            else if (selection.Name == "sprite_edit28") { MoveSprite(sprite_edit29, 2); }
            else if (selection.Name == "sprite_edit29") { MoveSprite(sprite_edit30, 2); }
            else if (selection.Name == "sprite_edit30") { MoveSprite(sprite_edit25, 2); }

            else if (selection.Name == "sprite_edit31") { MoveSprite(sprite_edit32, 2); }
            else if (selection.Name == "sprite_edit32") { MoveSprite(sprite_edit33, 2); }
            else if (selection.Name == "sprite_edit33") { MoveSprite(sprite_edit34, 2); }
            else if (selection.Name == "sprite_edit34") { MoveSprite(sprite_edit35, 2); }
            else if (selection.Name == "sprite_edit35") { MoveSprite(sprite_edit36, 2); }
            else if (selection.Name == "sprite_edit36") { MoveSprite(sprite_edit31, 2); }

            else if (selection.Name == "sprite_edit37") { MoveSprite(sprite_edit38, 2); }
            else if (selection.Name == "sprite_edit38") { MoveSprite(sprite_edit39, 2); }
            else if (selection.Name == "sprite_edit39") { MoveSprite(sprite_edit40, 2); }
            else if (selection.Name == "sprite_edit40") { MoveSprite(sprite_edit41, 2); }
            else if (selection.Name == "sprite_edit41") { MoveSprite(sprite_edit42, 2); }
            else if (selection.Name == "sprite_edit42") { MoveSprite(sprite_edit37, 2); }

            else if (selection.Name == "sprite_edit43") { MoveSprite(sprite_edit44, 2); }
            else if (selection.Name == "sprite_edit44") { MoveSprite(sprite_edit45, 2); }
            else if (selection.Name == "sprite_edit45") { MoveSprite(sprite_edit46, 2); }
            else if (selection.Name == "sprite_edit46") { MoveSprite(sprite_edit47, 2); }
            else if (selection.Name == "sprite_edit47") { MoveSprite(sprite_edit48, 2); }
            else if (selection.Name == "sprite_edit48") { MoveSprite(sprite_edit43, 2); }
        }

        private void sprite_down_Click(object sender, EventArgs e)
        {
            //VIEW
            if (selection.Name == "sprite_view1") { MoveSprite(sprite_view7, 1); }
            else if (selection.Name == "sprite_view2") { MoveSprite(sprite_view8, 1); }
            else if (selection.Name == "sprite_view3") { MoveSprite(sprite_view9, 1); }
            else if (selection.Name == "sprite_view4") { MoveSprite(sprite_view10, 1); }
            else if (selection.Name == "sprite_view5") { MoveSprite(sprite_view11, 1); }
            else if (selection.Name == "sprite_view6") { MoveSprite(sprite_view12, 1); }

            else if (selection.Name == "sprite_view7") { MoveSprite(sprite_view13, 1); }
            else if (selection.Name == "sprite_view8") { MoveSprite(sprite_view14, 1); }
            else if (selection.Name == "sprite_view9") { MoveSprite(sprite_view15, 1); }
            else if (selection.Name == "sprite_view10") { MoveSprite(sprite_view16, 1); }
            else if (selection.Name == "sprite_view11") { MoveSprite(sprite_view17, 1); }
            else if (selection.Name == "sprite_view12") { MoveSprite(sprite_view18, 1); }

            else if (selection.Name == "sprite_view13") { MoveSprite(sprite_view19, 1); }
            else if (selection.Name == "sprite_view14") { MoveSprite(sprite_view20, 1); }
            else if (selection.Name == "sprite_view15") { MoveSprite(sprite_view21, 1); }
            else if (selection.Name == "sprite_view16") { MoveSprite(sprite_view22, 1); }
            else if (selection.Name == "sprite_view17") { MoveSprite(sprite_view23, 1); }
            else if (selection.Name == "sprite_view18") { MoveSprite(sprite_view24, 1); }

            else if (selection.Name == "sprite_view19") { MoveSprite(sprite_view25, 1); }
            else if (selection.Name == "sprite_view20") { MoveSprite(sprite_view26, 1); }
            else if (selection.Name == "sprite_view21") { MoveSprite(sprite_view27, 1); }
            else if (selection.Name == "sprite_view22") { MoveSprite(sprite_view28, 1); }
            else if (selection.Name == "sprite_view23") { MoveSprite(sprite_view29, 1); }
            else if (selection.Name == "sprite_view24") { MoveSprite(sprite_view30, 1); }

            else if (selection.Name == "sprite_view25") { MoveSprite(sprite_view31, 1); }
            else if (selection.Name == "sprite_view26") { MoveSprite(sprite_view32, 1); }
            else if (selection.Name == "sprite_view27") { MoveSprite(sprite_view33, 1); }
            else if (selection.Name == "sprite_view28") { MoveSprite(sprite_view34, 1); }
            else if (selection.Name == "sprite_view29") { MoveSprite(sprite_view35, 1); }
            else if (selection.Name == "sprite_view30") { MoveSprite(sprite_view36, 1); }

            else if (selection.Name == "sprite_view31") { MoveSprite(sprite_view37, 1); }
            else if (selection.Name == "sprite_view32") { MoveSprite(sprite_view38, 1); }
            else if (selection.Name == "sprite_view33") { MoveSprite(sprite_view39, 1); }
            else if (selection.Name == "sprite_view34") { MoveSprite(sprite_view40, 1); }
            else if (selection.Name == "sprite_view35") { MoveSprite(sprite_view41, 1); }
            else if (selection.Name == "sprite_view36") { MoveSprite(sprite_view42, 1); }

            else if (selection.Name == "sprite_view37") { MoveSprite(sprite_view43, 1); }
            else if (selection.Name == "sprite_view38") { MoveSprite(sprite_view44, 1); }
            else if (selection.Name == "sprite_view39") { MoveSprite(sprite_view45, 1); }
            else if (selection.Name == "sprite_view40") { MoveSprite(sprite_view46, 1); }
            else if (selection.Name == "sprite_view41") { MoveSprite(sprite_view47, 1); }
            else if (selection.Name == "sprite_view42") { MoveSprite(sprite_view48, 1); }

            else if (selection.Name == "sprite_view43") { MoveSprite(sprite_view1, 1); }
            else if (selection.Name == "sprite_view44") { MoveSprite(sprite_view2, 1); }
            else if (selection.Name == "sprite_view45") { MoveSprite(sprite_view3, 1); }
            else if (selection.Name == "sprite_view46") { MoveSprite(sprite_view4, 1); }
            else if (selection.Name == "sprite_view47") { MoveSprite(sprite_view5, 1); }
            else if (selection.Name == "sprite_view48") { MoveSprite(sprite_view6, 1); }

            //EDIT
            else if (selection.Name == "sprite_edit1") { MoveSprite(sprite_edit7, 2); }
            else if (selection.Name == "sprite_edit2") { MoveSprite(sprite_edit8, 2); }
            else if (selection.Name == "sprite_edit3") { MoveSprite(sprite_edit9, 2); }
            else if (selection.Name == "sprite_edit4") { MoveSprite(sprite_edit10, 2); }
            else if (selection.Name == "sprite_edit5") { MoveSprite(sprite_edit11, 2); }
            else if (selection.Name == "sprite_edit6") { MoveSprite(sprite_edit12, 2); }

            else if (selection.Name == "sprite_edit7") { MoveSprite(sprite_edit13, 2); }
            else if (selection.Name == "sprite_edit8") { MoveSprite(sprite_edit14, 2); }
            else if (selection.Name == "sprite_edit9") { MoveSprite(sprite_edit15, 2); }
            else if (selection.Name == "sprite_edit10") { MoveSprite(sprite_edit16, 2); }
            else if (selection.Name == "sprite_edit11") { MoveSprite(sprite_edit17, 2); }
            else if (selection.Name == "sprite_edit12") { MoveSprite(sprite_edit18, 2); }

            else if (selection.Name == "sprite_edit13") { MoveSprite(sprite_edit19, 2); }
            else if (selection.Name == "sprite_edit14") { MoveSprite(sprite_edit20, 2); }
            else if (selection.Name == "sprite_edit15") { MoveSprite(sprite_edit21, 2); }
            else if (selection.Name == "sprite_edit16") { MoveSprite(sprite_edit22, 2); }
            else if (selection.Name == "sprite_edit17") { MoveSprite(sprite_edit23, 2); }
            else if (selection.Name == "sprite_edit18") { MoveSprite(sprite_edit24, 2); }

            else if (selection.Name == "sprite_edit19") { MoveSprite(sprite_edit25, 2); }
            else if (selection.Name == "sprite_edit20") { MoveSprite(sprite_edit26, 2); }
            else if (selection.Name == "sprite_edit21") { MoveSprite(sprite_edit27, 2); }
            else if (selection.Name == "sprite_edit22") { MoveSprite(sprite_edit28, 2); }
            else if (selection.Name == "sprite_edit23") { MoveSprite(sprite_edit29, 2); }
            else if (selection.Name == "sprite_edit24") { MoveSprite(sprite_edit30, 2); }

            else if (selection.Name == "sprite_edit25") { MoveSprite(sprite_edit31, 2); }
            else if (selection.Name == "sprite_edit26") { MoveSprite(sprite_edit32, 2); }
            else if (selection.Name == "sprite_edit27") { MoveSprite(sprite_edit33, 2); }
            else if (selection.Name == "sprite_edit28") { MoveSprite(sprite_edit34, 2); }
            else if (selection.Name == "sprite_edit29") { MoveSprite(sprite_edit35, 2); }
            else if (selection.Name == "sprite_edit30") { MoveSprite(sprite_edit36, 2); }

            else if (selection.Name == "sprite_edit31") { MoveSprite(sprite_edit37, 2); }
            else if (selection.Name == "sprite_edit32") { MoveSprite(sprite_edit38, 2); }
            else if (selection.Name == "sprite_edit33") { MoveSprite(sprite_edit39, 2); }
            else if (selection.Name == "sprite_edit34") { MoveSprite(sprite_edit40, 2); }
            else if (selection.Name == "sprite_edit35") { MoveSprite(sprite_edit41, 2); }
            else if (selection.Name == "sprite_edit36") { MoveSprite(sprite_edit42, 2); }

            else if (selection.Name == "sprite_edit37") { MoveSprite(sprite_edit43, 2); }
            else if (selection.Name == "sprite_edit38") { MoveSprite(sprite_edit44, 2); }
            else if (selection.Name == "sprite_edit39") { MoveSprite(sprite_edit45, 2); }
            else if (selection.Name == "sprite_edit40") { MoveSprite(sprite_edit46, 2); }
            else if (selection.Name == "sprite_edit41") { MoveSprite(sprite_edit47, 2); }
            else if (selection.Name == "sprite_edit42") { MoveSprite(sprite_edit48, 2); }

            else if (selection.Name == "sprite_edit43") { MoveSprite(sprite_edit1, 2); }
            else if (selection.Name == "sprite_edit44") { MoveSprite(sprite_edit2, 2); }
            else if (selection.Name == "sprite_edit45") { MoveSprite(sprite_edit3, 2); }
            else if (selection.Name == "sprite_edit46") { MoveSprite(sprite_edit4, 2); }
            else if (selection.Name == "sprite_edit47") { MoveSprite(sprite_edit5, 2); }
            else if (selection.Name == "sprite_edit48") { MoveSprite(sprite_edit6, 2); }
        }
        #endregion
        #region matriz explicativa
        /*
         * MATRIZ DE PICTUREBOX
         * [ 1][ 2]  [ 3][ 4]  [ 5][ 6]
         * [ 7][ 8]  [ 9][10]  [11][12]
         * 
         * [13][14]  [15][16]  [17][18]
         * [19][20]  [21][22]  [23][24]
         * 
         * [25][26]  [27][28]  [29][30]
         * [31][32]  [33][34]  [35][36]
         * 
         * [37][38]  [39][40]  [41][42]
         * [43][44]  [45][46]  [47][48]
         * 
         */
        #endregion
        #region Movendo os blocos de sprites de um canto para o outro ;D
        #region funções e variaveis
        //Funções e variaveis
        //Definindo a posição dos blocos
        PictureBox[] block_view1 = new PictureBox[4], block_view2 = new PictureBox[4], block_view3 = new PictureBox[4], block_view4 = new PictureBox[4], block_view5 = new PictureBox[4], block_view6 = new PictureBox[4], block_view7 = new PictureBox[4], block_view8 = new PictureBox[4], block_view9 = new PictureBox[4], block_view10 = new PictureBox[4], block_view11 = new PictureBox[4], block_view12 = new PictureBox[4];
        PictureBox[] block_edit1 = new PictureBox[4], block_edit2 = new PictureBox[4], block_edit3 = new PictureBox[4], block_edit4 = new PictureBox[4], block_edit5 = new PictureBox[4], block_edit6 = new PictureBox[4], block_edit7 = new PictureBox[4], block_edit8 = new PictureBox[4], block_edit9 = new PictureBox[4], block_edit10 = new PictureBox[4], block_edit11 = new PictureBox[4], block_edit12 = new PictureBox[4];

        private void loadBlocksPosition()
        {
            //BLOCO 1
            block_view1[0] = sprite_view1;
            block_view1[1] = sprite_view2;
            block_view1[2] = sprite_view7;
            block_view1[3] = sprite_view8;

            //BLOCO 2
            block_view2[0] = sprite_view3;
            block_view2[1] = sprite_view4;
            block_view2[2] = sprite_view9;
            block_view2[3] = sprite_view10;

            //BLOCO 3
            block_view3[0] = sprite_view5;
            block_view3[1] = sprite_view6;
            block_view3[2] = sprite_view11;
            block_view3[3] = sprite_view12;

            //BLOCO 4
            block_view4[0] = sprite_view13;
            block_view4[1] = sprite_view14;
            block_view4[2] = sprite_view19;
            block_view4[3] = sprite_view20;

            //BLOCO 5
            block_view5[0] = sprite_view15;
            block_view5[1] = sprite_view16;
            block_view5[2] = sprite_view21;
            block_view5[3] = sprite_view22;

            //BLOCO 6
            block_view6[0] = sprite_view17;
            block_view6[1] = sprite_view18;
            block_view6[2] = sprite_view23;
            block_view6[3] = sprite_view24;

            //BLOCO 7
            block_view7[0] = sprite_view25;
            block_view7[1] = sprite_view26;
            block_view7[2] = sprite_view31;
            block_view7[3] = sprite_view32;

            //BLOCO 8
            block_view8[0] = sprite_view27;
            block_view8[1] = sprite_view28;
            block_view8[2] = sprite_view33;
            block_view8[3] = sprite_view34;

            //BLOCO 9
            block_view9[0] = sprite_view29;
            block_view9[1] = sprite_view30;
            block_view9[2] = sprite_view35;
            block_view9[3] = sprite_view36;

            //BLOCO 10
            block_view10[0] = sprite_view37;
            block_view10[1] = sprite_view38;
            block_view10[2] = sprite_view43;
            block_view10[3] = sprite_view44;

            //BLOCO 11
            block_view11[0] = sprite_view39;
            block_view11[1] = sprite_view40;
            block_view11[2] = sprite_view45;
            block_view11[3] = sprite_view46;

            //BLOCO 12
            block_view12[0] = sprite_view41;
            block_view12[1] = sprite_view42;
            block_view12[2] = sprite_view47;
            block_view12[3] = sprite_view48;

            //BLOCO 1
            block_edit1[0] = sprite_edit1;
            block_edit1[1] = sprite_edit2;
            block_edit1[2] = sprite_edit7;
            block_edit1[3] = sprite_edit8;

            //BLOCO 2
            block_edit2[0] = sprite_edit3;
            block_edit2[1] = sprite_edit4;
            block_edit2[2] = sprite_edit9;
            block_edit2[3] = sprite_edit10;

            //BLOCO 3
            block_edit3[0] = sprite_edit5;
            block_edit3[1] = sprite_edit6;
            block_edit3[2] = sprite_edit11;
            block_edit3[3] = sprite_edit12;

            //BLOCO 4
            block_edit4[0] = sprite_edit13;
            block_edit4[1] = sprite_edit14;
            block_edit4[2] = sprite_edit19;
            block_edit4[3] = sprite_edit20;

            //BLOCO 5
            block_edit5[0] = sprite_edit15;
            block_edit5[1] = sprite_edit16;
            block_edit5[2] = sprite_edit21;
            block_edit5[3] = sprite_edit22;

            //BLOCO 6
            block_edit6[0] = sprite_edit17;
            block_edit6[1] = sprite_edit18;
            block_edit6[2] = sprite_edit23;
            block_edit6[3] = sprite_edit24;

            //BLOCO 7
            block_edit7[0] = sprite_edit25;
            block_edit7[1] = sprite_edit26;
            block_edit7[2] = sprite_edit31;
            block_edit7[3] = sprite_edit32;

            //BLOCO 8
            block_edit8[0] = sprite_edit27;
            block_edit8[1] = sprite_edit28;
            block_edit8[2] = sprite_edit33;
            block_edit8[3] = sprite_edit34;

            //BLOCO 9
            block_edit9[0] = sprite_edit29;
            block_edit9[1] = sprite_edit30;
            block_edit9[2] = sprite_edit35;
            block_edit9[3] = sprite_edit36;

            //BLOCO 10
            block_edit10[0] = sprite_edit37;
            block_edit10[1] = sprite_edit38;
            block_edit10[2] = sprite_edit43;
            block_edit10[3] = sprite_edit44;

            //BLOCO 11
            block_edit11[0] = sprite_edit39;
            block_edit11[1] = sprite_edit40;
            block_edit11[2] = sprite_edit45;
            block_edit11[3] = sprite_edit46;

            //BLOCO 12
            block_edit12[0] = sprite_edit41;
            block_edit12[1] = sprite_edit42;
            block_edit12[2] = sprite_edit47;
            block_edit12[3] = sprite_edit48;
        }

        private void MoveBlock(PictureBox[] pic1, PictureBox[] pic2, int type)
        {
            PictureBox[] tmp_pic = new PictureBox[4];
            tmp_pic[0] = new PictureBox();
            tmp_pic[1] = new PictureBox();
            tmp_pic[2] = new PictureBox();
            tmp_pic[3] = new PictureBox();

            tmp_pic[0].Image = pic1[0].Image;
            tmp_pic[0].Tag = pic1[0].Tag;
            tmp_pic[1].Image = pic1[1].Image;
            tmp_pic[1].Tag = pic1[1].Tag;
            tmp_pic[2].Image = pic1[2].Image;
            tmp_pic[2].Tag = pic1[2].Tag;
            tmp_pic[3].Image = pic1[3].Image;
            tmp_pic[3].Tag = pic1[3].Tag;

            pic1[0].Image = pic2[0].Image;
            pic1[0].Tag = pic2[0].Tag;
            pic1[1].Image = pic2[1].Image;
            pic1[1].Tag = pic2[1].Tag;
            pic1[2].Image = pic2[2].Image;
            pic1[2].Tag = pic2[2].Tag;
            pic1[3].Image = pic2[3].Image;
            pic1[3].Tag = pic2[3].Tag;

            pic2[0].Image = tmp_pic[0].Image;
            pic2[0].Tag = tmp_pic[0].Tag;
            pic2[1].Image = tmp_pic[1].Image;
            pic2[1].Tag = tmp_pic[1].Tag;
            pic2[2].Image = tmp_pic[2].Image;
            pic2[2].Tag = tmp_pic[2].Tag;
            pic2[3].Image = tmp_pic[3].Image;
            pic2[3].Tag = tmp_pic[3].Tag;

            //View
            if (type == 1)
            {
                SelectMeView(pic2[3]);
            }

            //Edit
            else if (type == 2)
            {
                SelectMeEdit(pic2[3]);
            }
        }
        #endregion

        private void block_left_Click(object sender, EventArgs e)
        {
            loadBlocksPosition();
            //VIEW
            if      (selection.Name == "sprite_view1" || selection.Name == "sprite_view2" || selection.Name == "sprite_view7" || selection.Name == "sprite_view8") { MoveBlock(block_view1, block_view3, 1); }
            else if (selection.Name == "sprite_view3" || selection.Name == "sprite_view4" || selection.Name == "sprite_view9" || selection.Name == "sprite_view10") { MoveBlock(block_view2, block_view1, 1); }
            else if (selection.Name == "sprite_view5" || selection.Name == "sprite_view6" || selection.Name == "sprite_view11" || selection.Name == "sprite_view12") { MoveBlock(block_view3, block_view2, 1); }
            else if (selection.Name == "sprite_view13" || selection.Name == "sprite_view14" || selection.Name == "sprite_view19" || selection.Name == "sprite_view20") { MoveBlock(block_view4, block_view6, 1); }
            else if (selection.Name == "sprite_view15" || selection.Name == "sprite_view16" || selection.Name == "sprite_view21" || selection.Name == "sprite_view22") { MoveBlock(block_view5, block_view4, 1); }
            else if (selection.Name == "sprite_view17" || selection.Name == "sprite_view18" || selection.Name == "sprite_view23" || selection.Name == "sprite_view24") { MoveBlock(block_view6, block_view5, 1); }
            else if (selection.Name == "sprite_view25" || selection.Name == "sprite_view26" || selection.Name == "sprite_view31" || selection.Name == "sprite_view32") { MoveBlock(block_view7, block_view9, 1); }
            else if (selection.Name == "sprite_view27" || selection.Name == "sprite_view28" || selection.Name == "sprite_view33" || selection.Name == "sprite_view34") { MoveBlock(block_view8, block_view7, 1); }
            else if (selection.Name == "sprite_view29" || selection.Name == "sprite_view30" || selection.Name == "sprite_view35" || selection.Name == "sprite_view36") { MoveBlock(block_view9, block_view8, 1); }
            else if (selection.Name == "sprite_view37" || selection.Name == "sprite_view38" || selection.Name == "sprite_view43" || selection.Name == "sprite_view44") { MoveBlock(block_view10, block_view12, 1); }
            else if (selection.Name == "sprite_view39" || selection.Name == "sprite_view40" || selection.Name == "sprite_view45" || selection.Name == "sprite_view46") { MoveBlock(block_view11, block_view10, 1); }
            else if (selection.Name == "sprite_view41" || selection.Name == "sprite_view42" || selection.Name == "sprite_view47" || selection.Name == "sprite_view48") { MoveBlock(block_view12, block_view11, 1); }
            
            //Edit
            else if (selection.Name == "sprite_edit1" || selection.Name == "sprite_edit2" || selection.Name == "sprite_edit7" || selection.Name == "sprite_edit8") { MoveBlock(block_edit1, block_edit3, 2); }
            else if (selection.Name == "sprite_edit3" || selection.Name == "sprite_edit4" || selection.Name == "sprite_edit9" || selection.Name == "sprite_edit10") { MoveBlock(block_edit2, block_edit1, 2); }
            else if (selection.Name == "sprite_edit5" || selection.Name == "sprite_edit6" || selection.Name == "sprite_edit11" || selection.Name == "sprite_edit12") { MoveBlock(block_edit3, block_edit2, 2); }
            else if (selection.Name == "sprite_edit13" || selection.Name == "sprite_edit14" || selection.Name == "sprite_edit19" || selection.Name == "sprite_edit20") { MoveBlock(block_edit4, block_edit6, 2); }
            else if (selection.Name == "sprite_edit15" || selection.Name == "sprite_edit16" || selection.Name == "sprite_edit21" || selection.Name == "sprite_edit22") { MoveBlock(block_edit5, block_edit4, 2); }
            else if (selection.Name == "sprite_edit17" || selection.Name == "sprite_edit18" || selection.Name == "sprite_edit23" || selection.Name == "sprite_edit24") { MoveBlock(block_edit6, block_edit5, 2); }
            else if (selection.Name == "sprite_edit25" || selection.Name == "sprite_edit26" || selection.Name == "sprite_edit31" || selection.Name == "sprite_edit32") { MoveBlock(block_edit7, block_edit9, 2); }
            else if (selection.Name == "sprite_edit27" || selection.Name == "sprite_edit28" || selection.Name == "sprite_edit33" || selection.Name == "sprite_edit34") { MoveBlock(block_edit8, block_edit7, 2); }
            else if (selection.Name == "sprite_edit29" || selection.Name == "sprite_edit30" || selection.Name == "sprite_edit35" || selection.Name == "sprite_edit36") { MoveBlock(block_edit9, block_edit8, 2); }
            else if (selection.Name == "sprite_edit37" || selection.Name == "sprite_edit38" || selection.Name == "sprite_edit43" || selection.Name == "sprite_edit44") { MoveBlock(block_edit10, block_edit12, 2); }
            else if (selection.Name == "sprite_edit39" || selection.Name == "sprite_edit40" || selection.Name == "sprite_edit45" || selection.Name == "sprite_edit46") { MoveBlock(block_edit11, block_edit10, 2); }
            else if (selection.Name == "sprite_edit41" || selection.Name == "sprite_edit42" || selection.Name == "sprite_edit47" || selection.Name == "sprite_edit48") { MoveBlock(block_edit12, block_edit11, 2); }
        }

        private void block_up_Click(object sender, EventArgs e)
        {
            loadBlocksPosition();
            //VIEW
            if (selection.Name == "sprite_view1" || selection.Name == "sprite_view2" || selection.Name == "sprite_view7" || selection.Name == "sprite_view8") { MoveBlock(block_view1, block_view10, 1); }
            else if (selection.Name == "sprite_view3" || selection.Name == "sprite_view4" || selection.Name == "sprite_view9" || selection.Name == "sprite_view10") { MoveBlock(block_view2, block_view11, 1); }
            else if (selection.Name == "sprite_view5" || selection.Name == "sprite_view6" || selection.Name == "sprite_view11" || selection.Name == "sprite_view12") { MoveBlock(block_view3, block_view12, 1); }
            else if (selection.Name == "sprite_view13" || selection.Name == "sprite_view14" || selection.Name == "sprite_view19" || selection.Name == "sprite_view20") { MoveBlock(block_view4, block_view1, 1); }
            else if (selection.Name == "sprite_view15" || selection.Name == "sprite_view16" || selection.Name == "sprite_view21" || selection.Name == "sprite_view22") { MoveBlock(block_view5, block_view2, 1); }
            else if (selection.Name == "sprite_view17" || selection.Name == "sprite_view18" || selection.Name == "sprite_view23" || selection.Name == "sprite_view24") { MoveBlock(block_view6, block_view3, 1); }
            else if (selection.Name == "sprite_view25" || selection.Name == "sprite_view26" || selection.Name == "sprite_view31" || selection.Name == "sprite_view32") { MoveBlock(block_view7, block_view4, 1); }
            else if (selection.Name == "sprite_view27" || selection.Name == "sprite_view28" || selection.Name == "sprite_view33" || selection.Name == "sprite_view34") { MoveBlock(block_view8, block_view5, 1); }
            else if (selection.Name == "sprite_view29" || selection.Name == "sprite_view30" || selection.Name == "sprite_view35" || selection.Name == "sprite_view36") { MoveBlock(block_view9, block_view6, 1); }
            else if (selection.Name == "sprite_view37" || selection.Name == "sprite_view38" || selection.Name == "sprite_view43" || selection.Name == "sprite_view44") { MoveBlock(block_view10, block_view7, 1); }
            else if (selection.Name == "sprite_view39" || selection.Name == "sprite_view40" || selection.Name == "sprite_view45" || selection.Name == "sprite_view46") { MoveBlock(block_view11, block_view8, 1); }
            else if (selection.Name == "sprite_view41" || selection.Name == "sprite_view42" || selection.Name == "sprite_view47" || selection.Name == "sprite_view48") { MoveBlock(block_view12, block_view9, 1); }

            //EDIT
            else if (selection.Name == "sprite_edit1" || selection.Name == "sprite_edit2" || selection.Name == "sprite_edit7" || selection.Name == "sprite_edit8") { MoveBlock(block_edit1, block_edit10, 2); }
            else if (selection.Name == "sprite_edit3" || selection.Name == "sprite_edit4" || selection.Name == "sprite_edit9" || selection.Name == "sprite_edit10") { MoveBlock(block_edit2, block_edit11, 2); }
            else if (selection.Name == "sprite_edit5" || selection.Name == "sprite_edit6" || selection.Name == "sprite_edit11" || selection.Name == "sprite_edit12") { MoveBlock(block_edit3, block_edit12, 2); }
            else if (selection.Name == "sprite_edit13" || selection.Name == "sprite_edit14" || selection.Name == "sprite_edit19" || selection.Name == "sprite_edit20") { MoveBlock(block_edit4, block_edit1, 2); }
            else if (selection.Name == "sprite_edit15" || selection.Name == "sprite_edit16" || selection.Name == "sprite_edit21" || selection.Name == "sprite_edit22") { MoveBlock(block_edit5, block_edit2, 2); }
            else if (selection.Name == "sprite_edit17" || selection.Name == "sprite_edit18" || selection.Name == "sprite_edit23" || selection.Name == "sprite_edit24") { MoveBlock(block_edit6, block_edit3, 2); }
            else if (selection.Name == "sprite_edit25" || selection.Name == "sprite_edit26" || selection.Name == "sprite_edit31" || selection.Name == "sprite_edit32") { MoveBlock(block_edit7, block_edit4, 2); }
            else if (selection.Name == "sprite_edit27" || selection.Name == "sprite_edit28" || selection.Name == "sprite_edit33" || selection.Name == "sprite_edit34") { MoveBlock(block_edit8, block_edit5, 2); }
            else if (selection.Name == "sprite_edit29" || selection.Name == "sprite_edit30" || selection.Name == "sprite_edit35" || selection.Name == "sprite_edit36") { MoveBlock(block_edit9, block_edit6, 2); }
            else if (selection.Name == "sprite_edit37" || selection.Name == "sprite_edit38" || selection.Name == "sprite_edit43" || selection.Name == "sprite_edit44") { MoveBlock(block_edit10, block_edit7, 2); }
            else if (selection.Name == "sprite_edit39" || selection.Name == "sprite_edit40" || selection.Name == "sprite_edit45" || selection.Name == "sprite_edit46") { MoveBlock(block_edit11, block_edit8, 2); }
            else if (selection.Name == "sprite_edit41" || selection.Name == "sprite_edit42" || selection.Name == "sprite_edit47" || selection.Name == "sprite_edit48") { MoveBlock(block_edit12, block_edit9, 2); }
        }

        private void block_right_Click(object sender, EventArgs e)
        {
            loadBlocksPosition();
            //VIEW
            if      (selection.Name == "sprite_view1" || selection.Name == "sprite_view2" || selection.Name == "sprite_view7" || selection.Name == "sprite_view8") { MoveBlock(block_view1, block_view2, 1); }
            else if (selection.Name == "sprite_view3" || selection.Name == "sprite_view4" || selection.Name == "sprite_view9" || selection.Name == "sprite_view10") { MoveBlock(block_view2, block_view3, 1); }
            else if (selection.Name == "sprite_view5" || selection.Name == "sprite_view6" || selection.Name == "sprite_view11" || selection.Name == "sprite_view12") { MoveBlock(block_view3, block_view1, 1); }
            else if (selection.Name == "sprite_view13" || selection.Name == "sprite_view14" || selection.Name == "sprite_view19" || selection.Name == "sprite_view20") { MoveBlock(block_view4, block_view5, 1); }
            else if (selection.Name == "sprite_view15" || selection.Name == "sprite_view16" || selection.Name == "sprite_view21" || selection.Name == "sprite_view22") { MoveBlock(block_view5, block_view6, 1); }
            else if (selection.Name == "sprite_view17" || selection.Name == "sprite_view18" || selection.Name == "sprite_view23" || selection.Name == "sprite_view24") { MoveBlock(block_view6, block_view4, 1); }
            else if (selection.Name == "sprite_view25" || selection.Name == "sprite_view26" || selection.Name == "sprite_view31" || selection.Name == "sprite_view32") { MoveBlock(block_view7, block_view8, 1); }
            else if (selection.Name == "sprite_view27" || selection.Name == "sprite_view28" || selection.Name == "sprite_view33" || selection.Name == "sprite_view34") { MoveBlock(block_view8, block_view9, 1); }
            else if (selection.Name == "sprite_view29" || selection.Name == "sprite_view30" || selection.Name == "sprite_view35" || selection.Name == "sprite_view36") { MoveBlock(block_view9, block_view7, 1); }
            else if (selection.Name == "sprite_view37" || selection.Name == "sprite_view38" || selection.Name == "sprite_view43" || selection.Name == "sprite_view44") { MoveBlock(block_view10, block_view11, 1); }
            else if (selection.Name == "sprite_view39" || selection.Name == "sprite_view40" || selection.Name == "sprite_view45" || selection.Name == "sprite_view46") { MoveBlock(block_view11, block_view12, 1); }
            else if (selection.Name == "sprite_view41" || selection.Name == "sprite_view42" || selection.Name == "sprite_view47" || selection.Name == "sprite_view48") { MoveBlock(block_view12, block_view10, 1); }

            //EDIT
            else if (selection.Name == "sprite_edit1" || selection.Name == "sprite_edit2" || selection.Name == "sprite_edit7" || selection.Name == "sprite_edit8") { MoveBlock(block_edit1, block_edit2, 2); }
            else if (selection.Name == "sprite_edit3" || selection.Name == "sprite_edit4" || selection.Name == "sprite_edit9" || selection.Name == "sprite_edit10") { MoveBlock(block_edit2, block_edit3, 2); }
            else if (selection.Name == "sprite_edit5" || selection.Name == "sprite_edit6" || selection.Name == "sprite_edit11" || selection.Name == "sprite_edit12") { MoveBlock(block_edit3, block_edit1, 2); }
            else if (selection.Name == "sprite_edit13" || selection.Name == "sprite_edit14" || selection.Name == "sprite_edit19" || selection.Name == "sprite_edit20") { MoveBlock(block_edit4, block_edit5, 2); }
            else if (selection.Name == "sprite_edit15" || selection.Name == "sprite_edit16" || selection.Name == "sprite_edit21" || selection.Name == "sprite_edit22") { MoveBlock(block_edit5, block_edit6, 2); }
            else if (selection.Name == "sprite_edit17" || selection.Name == "sprite_edit18" || selection.Name == "sprite_edit23" || selection.Name == "sprite_edit24") { MoveBlock(block_edit6, block_edit4, 2); }
            else if (selection.Name == "sprite_edit25" || selection.Name == "sprite_edit26" || selection.Name == "sprite_edit31" || selection.Name == "sprite_edit32") { MoveBlock(block_edit7, block_edit8, 2); }
            else if (selection.Name == "sprite_edit27" || selection.Name == "sprite_edit28" || selection.Name == "sprite_edit33" || selection.Name == "sprite_edit34") { MoveBlock(block_edit8, block_edit9, 2); }
            else if (selection.Name == "sprite_edit29" || selection.Name == "sprite_edit30" || selection.Name == "sprite_edit35" || selection.Name == "sprite_edit36") { MoveBlock(block_edit9, block_edit7, 2); }
            else if (selection.Name == "sprite_edit37" || selection.Name == "sprite_edit38" || selection.Name == "sprite_edit43" || selection.Name == "sprite_edit44") { MoveBlock(block_edit10, block_edit11, 2); }
            else if (selection.Name == "sprite_edit39" || selection.Name == "sprite_edit40" || selection.Name == "sprite_edit45" || selection.Name == "sprite_edit46") { MoveBlock(block_edit11, block_edit12, 2); }
            else if (selection.Name == "sprite_edit41" || selection.Name == "sprite_edit42" || selection.Name == "sprite_edit47" || selection.Name == "sprite_edit48") { MoveBlock(block_edit12, block_edit10, 2); }
        }

        private void block_down_Click(object sender, EventArgs e)
        {
            loadBlocksPosition();
            //VIEW
            if (selection.Name == "sprite_view1" || selection.Name == "sprite_view2" || selection.Name == "sprite_view7" || selection.Name == "sprite_view8") { MoveBlock(block_view1, block_view4, 1); }
            else if (selection.Name == "sprite_view3" || selection.Name == "sprite_view4" || selection.Name == "sprite_view9" || selection.Name == "sprite_view10") { MoveBlock(block_view2, block_view5, 1); }
            else if (selection.Name == "sprite_view5" || selection.Name == "sprite_view6" || selection.Name == "sprite_view11" || selection.Name == "sprite_view12") { MoveBlock(block_view3, block_view6, 1); }
            else if (selection.Name == "sprite_view13" || selection.Name == "sprite_view14" || selection.Name == "sprite_view19" || selection.Name == "sprite_view20") { MoveBlock(block_view4, block_view7, 1); }
            else if (selection.Name == "sprite_view15" || selection.Name == "sprite_view16" || selection.Name == "sprite_view21" || selection.Name == "sprite_view22") { MoveBlock(block_view5, block_view8, 1); }
            else if (selection.Name == "sprite_view17" || selection.Name == "sprite_view18" || selection.Name == "sprite_view23" || selection.Name == "sprite_view24") { MoveBlock(block_view6, block_view9, 1); }
            else if (selection.Name == "sprite_view25" || selection.Name == "sprite_view26" || selection.Name == "sprite_view31" || selection.Name == "sprite_view32") { MoveBlock(block_view7, block_view10, 1); }
            else if (selection.Name == "sprite_view27" || selection.Name == "sprite_view28" || selection.Name == "sprite_view33" || selection.Name == "sprite_view34") { MoveBlock(block_view8, block_view11, 1); }
            else if (selection.Name == "sprite_view29" || selection.Name == "sprite_view30" || selection.Name == "sprite_view35" || selection.Name == "sprite_view36") { MoveBlock(block_view9, block_view12, 1); }
            else if (selection.Name == "sprite_view37" || selection.Name == "sprite_view38" || selection.Name == "sprite_view43" || selection.Name == "sprite_view44") { MoveBlock(block_view10, block_view1, 1); }
            else if (selection.Name == "sprite_view39" || selection.Name == "sprite_view40" || selection.Name == "sprite_view45" || selection.Name == "sprite_view46") { MoveBlock(block_view11, block_view2, 1); }
            else if (selection.Name == "sprite_view41" || selection.Name == "sprite_view42" || selection.Name == "sprite_view47" || selection.Name == "sprite_view48") { MoveBlock(block_view12, block_view3, 1); }

            //EDIT
            else if (selection.Name == "sprite_edit1" || selection.Name == "sprite_edit2" || selection.Name == "sprite_edit7" || selection.Name == "sprite_edit8") { MoveBlock(block_edit1, block_edit4, 2); }
            else if (selection.Name == "sprite_edit3" || selection.Name == "sprite_edit4" || selection.Name == "sprite_edit9" || selection.Name == "sprite_edit10") { MoveBlock(block_edit2, block_edit5, 2); }
            else if (selection.Name == "sprite_edit5" || selection.Name == "sprite_edit6" || selection.Name == "sprite_edit11" || selection.Name == "sprite_edit12") { MoveBlock(block_edit3, block_edit6, 2); }
            else if (selection.Name == "sprite_edit13" || selection.Name == "sprite_edit14" || selection.Name == "sprite_edit19" || selection.Name == "sprite_edit20") { MoveBlock(block_edit4, block_edit7, 2); }
            else if (selection.Name == "sprite_edit15" || selection.Name == "sprite_edit16" || selection.Name == "sprite_edit21" || selection.Name == "sprite_edit22") { MoveBlock(block_edit5, block_edit8, 2); }
            else if (selection.Name == "sprite_edit17" || selection.Name == "sprite_edit18" || selection.Name == "sprite_edit23" || selection.Name == "sprite_edit24") { MoveBlock(block_edit6, block_edit9, 2); }
            else if (selection.Name == "sprite_edit25" || selection.Name == "sprite_edit26" || selection.Name == "sprite_edit31" || selection.Name == "sprite_edit32") { MoveBlock(block_edit7, block_edit10, 2); }
            else if (selection.Name == "sprite_edit27" || selection.Name == "sprite_edit28" || selection.Name == "sprite_edit33" || selection.Name == "sprite_edit34") { MoveBlock(block_edit8, block_edit11, 2); }
            else if (selection.Name == "sprite_edit29" || selection.Name == "sprite_edit30" || selection.Name == "sprite_edit35" || selection.Name == "sprite_edit36") { MoveBlock(block_edit9, block_edit12, 2); }
            else if (selection.Name == "sprite_edit37" || selection.Name == "sprite_edit38" || selection.Name == "sprite_edit43" || selection.Name == "sprite_edit44") { MoveBlock(block_edit10, block_edit1, 2); }
            else if (selection.Name == "sprite_edit39" || selection.Name == "sprite_edit40" || selection.Name == "sprite_edit45" || selection.Name == "sprite_edit46") { MoveBlock(block_edit11, block_edit2, 2); }
            else if (selection.Name == "sprite_edit41" || selection.Name == "sprite_edit42" || selection.Name == "sprite_edit47" || selection.Name == "sprite_edit48") { MoveBlock(block_edit12, block_edit3, 2); }
        }
        #endregion
        #region matriz explicativa
        /*
         * MATRIZ SIMPLES
         * [ 1] [ 2] [ 3]
         * [ 4] [ 5] [ 6]
         * [ 7] [ 8] [ 9]
         * [10] [11] [12]
         */
        #endregion

        //EXPORTANDO ;D
        #region Botão que ajusta as sprites
        public void adjustEditSprites(PictureBox view, PictureBox edit)
        {
            if (view.Image != null && edit.Image == null)
            {
                edit.Image = pink;
            }

            else if (view.Image == null && edit.Image != null)
            {
                edit.Image = null;
            }
        }

        private void fill_voids_Click(object sender, EventArgs e)
        {
            string isok = MessageBox.Show("This can make you lost any data from Edit Outfit", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning).ToString();
            if (isok == "OK")
            {
                adjustEditSprites(sprite_view1, sprite_edit1);
                adjustEditSprites(sprite_view2, sprite_edit2);
                adjustEditSprites(sprite_view3, sprite_edit3);
                adjustEditSprites(sprite_view4, sprite_edit4);
                adjustEditSprites(sprite_view5, sprite_edit5);
                adjustEditSprites(sprite_view6, sprite_edit6);
                adjustEditSprites(sprite_view7, sprite_edit7);
                adjustEditSprites(sprite_view8, sprite_edit8);
                adjustEditSprites(sprite_view9, sprite_edit9);
                adjustEditSprites(sprite_view10, sprite_edit10);
                adjustEditSprites(sprite_view11, sprite_edit11);
                adjustEditSprites(sprite_view12, sprite_edit12);
                adjustEditSprites(sprite_view13, sprite_edit13);
                adjustEditSprites(sprite_view14, sprite_edit14);
                adjustEditSprites(sprite_view15, sprite_edit15);
                adjustEditSprites(sprite_view16, sprite_edit16);
                adjustEditSprites(sprite_view17, sprite_edit17);
                adjustEditSprites(sprite_view18, sprite_edit18);
                adjustEditSprites(sprite_view19, sprite_edit19);
                adjustEditSprites(sprite_view20, sprite_edit20);
                adjustEditSprites(sprite_view21, sprite_edit21);
                adjustEditSprites(sprite_view22, sprite_edit22);
                adjustEditSprites(sprite_view23, sprite_edit23);
                adjustEditSprites(sprite_view24, sprite_edit24);
                adjustEditSprites(sprite_view25, sprite_edit25);
                adjustEditSprites(sprite_view26, sprite_edit26);
                adjustEditSprites(sprite_view27, sprite_edit27);
                adjustEditSprites(sprite_view28, sprite_edit28);
                adjustEditSprites(sprite_view29, sprite_edit29);
                adjustEditSprites(sprite_view30, sprite_edit30);
                adjustEditSprites(sprite_view31, sprite_edit31);
                adjustEditSprites(sprite_view32, sprite_edit32);
                adjustEditSprites(sprite_view33, sprite_edit33);
                adjustEditSprites(sprite_view34, sprite_edit34);
                adjustEditSprites(sprite_view35, sprite_edit35);
                adjustEditSprites(sprite_view36, sprite_edit36);
                adjustEditSprites(sprite_view37, sprite_edit37);
                adjustEditSprites(sprite_view38, sprite_edit38);
                adjustEditSprites(sprite_view39, sprite_edit39);
                adjustEditSprites(sprite_view40, sprite_edit40);
                adjustEditSprites(sprite_view41, sprite_edit41);
                adjustEditSprites(sprite_view42, sprite_edit42);
                adjustEditSprites(sprite_view43, sprite_edit43);
                adjustEditSprites(sprite_view44, sprite_edit44);
                adjustEditSprites(sprite_view45, sprite_edit45);
                adjustEditSprites(sprite_view46, sprite_edit46);
                adjustEditSprites(sprite_view47, sprite_edit47);
                adjustEditSprites(sprite_view48, sprite_edit48);
            }
        }
        #endregion
        #region Funções referente a exportação das imagens
        private int CanExport(Image view, Image edit, int AlreadyError)
        {
            if (view != null && edit == null && AlreadyError != 2) //Erro 1 não substitui o erro 2
            {
                return 1; //Se deixar o usuário exportar desse jeito, as sprites do view vão se misturar com as do edit
            }

            else if (view == null && edit != null)
            {
                return 2; //Impossível exportar
            }

            else if (AlreadyError == 0) //Esse só pode retornar se não tiver nem 1 nem 2 no erro já
            {
                return 0; //Pode exportar, não há defeito nenhum
            }

            else
            {
                return AlreadyError;
            }
        }

        private void ExportImage(PictureBox view, PictureBox edit, string path)
        {
            if (edit.Image != null)
            {
                edit.Image.Save(path + "\\" + view.Tag, ImageFormat.Bmp);
            }
        }
        #endregion
        #region exportando
        private void ExportButton_Click(object sender, EventArgs e)
        {
            #region Verificando se é possivel exportar as sprites
            int ExportMessage = 0;
            ExportMessage = CanExport(sprite_view1.Image, sprite_edit1.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view2.Image, sprite_edit2.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view3.Image, sprite_edit3.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view4.Image, sprite_edit4.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view5.Image, sprite_edit5.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view6.Image, sprite_edit6.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view7.Image, sprite_edit7.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view8.Image, sprite_edit8.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view9.Image, sprite_edit9.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view10.Image, sprite_edit10.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view11.Image, sprite_edit11.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view12.Image, sprite_edit12.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view13.Image, sprite_edit13.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view14.Image, sprite_edit14.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view15.Image, sprite_edit15.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view16.Image, sprite_edit16.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view17.Image, sprite_edit17.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view18.Image, sprite_edit18.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view19.Image, sprite_edit19.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view20.Image, sprite_edit20.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view21.Image, sprite_edit21.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view22.Image, sprite_edit22.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view23.Image, sprite_edit23.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view24.Image, sprite_edit24.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view25.Image, sprite_edit25.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view26.Image, sprite_edit26.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view27.Image, sprite_edit27.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view28.Image, sprite_edit28.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view29.Image, sprite_edit29.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view30.Image, sprite_edit30.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view31.Image, sprite_edit31.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view32.Image, sprite_edit32.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view33.Image, sprite_edit33.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view34.Image, sprite_edit34.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view35.Image, sprite_edit35.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view36.Image, sprite_edit36.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view37.Image, sprite_edit37.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view38.Image, sprite_edit38.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view39.Image, sprite_edit39.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view40.Image, sprite_edit40.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view41.Image, sprite_edit41.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view42.Image, sprite_edit42.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view43.Image, sprite_edit43.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view44.Image, sprite_edit44.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view45.Image, sprite_edit45.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view46.Image, sprite_edit46.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view47.Image, sprite_edit47.Image, ExportMessage);
            ExportMessage = CanExport(sprite_view48.Image, sprite_edit48.Image, ExportMessage);

            if (ExportMessage == 1)
            {
                MessageBox.Show("The exportation can contain errors,\nclick in Adjust Edit Image before export.", "::ERROR::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (ExportMessage == 2)
            {
                MessageBox.Show("Impossible to export:\nSome images in Edit occupies void places in View.", "::ERROR::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
            #region Exportando as imagens para o local escolhido
            if (ExportMessage == 0)
            {
                FolderBrowserDialog export_place = new FolderBrowserDialog();
                if (export_place.ShowDialog() == DialogResult.OK)
                {
                    string exp_path = export_place.SelectedPath;
                    if (exp_path != "")
                    {
                        ExportImage(sprite_view1, sprite_edit1, exp_path);
                        ExportImage(sprite_view2, sprite_edit2, exp_path);
                        ExportImage(sprite_view3, sprite_edit3, exp_path);
                        ExportImage(sprite_view4, sprite_edit4, exp_path);
                        ExportImage(sprite_view5, sprite_edit5, exp_path);
                        ExportImage(sprite_view6, sprite_edit6, exp_path);
                        ExportImage(sprite_view7, sprite_edit7, exp_path);
                        ExportImage(sprite_view8, sprite_edit8, exp_path);
                        ExportImage(sprite_view9, sprite_edit9, exp_path);
                        ExportImage(sprite_view10, sprite_edit10, exp_path);
                        ExportImage(sprite_view11, sprite_edit11, exp_path);
                        ExportImage(sprite_view12, sprite_edit12, exp_path);
                        ExportImage(sprite_view13, sprite_edit13, exp_path);
                        ExportImage(sprite_view14, sprite_edit14, exp_path);
                        ExportImage(sprite_view15, sprite_edit15, exp_path);
                        ExportImage(sprite_view16, sprite_edit16, exp_path);
                        ExportImage(sprite_view17, sprite_edit17, exp_path);
                        ExportImage(sprite_view18, sprite_edit18, exp_path);
                        ExportImage(sprite_view19, sprite_edit19, exp_path);
                        ExportImage(sprite_view20, sprite_edit20, exp_path);
                        ExportImage(sprite_view21, sprite_edit21, exp_path);
                        ExportImage(sprite_view22, sprite_edit22, exp_path);
                        ExportImage(sprite_view23, sprite_edit23, exp_path);
                        ExportImage(sprite_view24, sprite_edit24, exp_path);
                        ExportImage(sprite_view25, sprite_edit25, exp_path);
                        ExportImage(sprite_view26, sprite_edit26, exp_path);
                        ExportImage(sprite_view27, sprite_edit27, exp_path);
                        ExportImage(sprite_view28, sprite_edit28, exp_path);
                        ExportImage(sprite_view29, sprite_edit29, exp_path);
                        ExportImage(sprite_view30, sprite_edit30, exp_path);
                        ExportImage(sprite_view31, sprite_edit31, exp_path);
                        ExportImage(sprite_view32, sprite_edit32, exp_path);
                        ExportImage(sprite_view33, sprite_edit33, exp_path);
                        ExportImage(sprite_view34, sprite_edit34, exp_path);
                        ExportImage(sprite_view35, sprite_edit35, exp_path);
                        ExportImage(sprite_view36, sprite_edit36, exp_path);
                        ExportImage(sprite_view37, sprite_edit37, exp_path);
                        ExportImage(sprite_view38, sprite_edit38, exp_path);
                        ExportImage(sprite_view39, sprite_edit39, exp_path);
                        ExportImage(sprite_view40, sprite_edit40, exp_path);
                        ExportImage(sprite_view41, sprite_edit41, exp_path);
                        ExportImage(sprite_view42, sprite_edit42, exp_path);
                        ExportImage(sprite_view43, sprite_edit43, exp_path);
                        ExportImage(sprite_view44, sprite_edit44, exp_path);
                        ExportImage(sprite_view45, sprite_edit45, exp_path);
                        ExportImage(sprite_view46, sprite_edit46, exp_path);
                        ExportImage(sprite_view47, sprite_edit47, exp_path);
                        ExportImage(sprite_view48, sprite_edit48, exp_path);
                        MessageBox.Show("Exportation complete.", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("You need to select a folder.", "::ERROR::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion
        }
        #endregion

        //CONVERÇÃO 48 PARA 1
        #region exportando as 48 imagens para uma
        private void convert48to1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(192, 256, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (sprite_view1.Image != null) { g.DrawImage(sprite_view1.Image, 0, 0, 32, 32); }
                if (sprite_view2.Image != null) { g.DrawImage(sprite_view2.Image, 32, 0, 32, 32); }
                if (sprite_view3.Image != null) { g.DrawImage(sprite_view3.Image, 64, 0, 32, 32); }
                if (sprite_view4.Image != null) { g.DrawImage(sprite_view4.Image, 96, 0, 32, 32); }
                if (sprite_view5.Image != null) { g.DrawImage(sprite_view5.Image, 128, 0, 32, 32); }
                if (sprite_view6.Image != null) { g.DrawImage(sprite_view6.Image, 160, 0, 32, 32); }

                if (sprite_view7.Image != null) { g.DrawImage(sprite_view7.Image, 0, 32, 32, 32); }
                if (sprite_view8.Image != null) { g.DrawImage(sprite_view8.Image, 32, 32, 32, 32); }
                if (sprite_view9.Image != null) { g.DrawImage(sprite_view9.Image, 64, 32, 32, 32); }
                if (sprite_view10.Image != null) { g.DrawImage(sprite_view10.Image, 96, 32, 32, 32); }
                if (sprite_view11.Image != null) { g.DrawImage(sprite_view11.Image, 128, 32, 32, 32); }
                if (sprite_view12.Image != null) { g.DrawImage(sprite_view12.Image, 160, 32, 32, 32); }

                if (sprite_view13.Image != null) { g.DrawImage(sprite_view13.Image, 0, 64, 32, 32); }
                if (sprite_view14.Image != null) { g.DrawImage(sprite_view14.Image, 32, 64, 32, 32); }
                if (sprite_view15.Image != null) { g.DrawImage(sprite_view15.Image, 64, 64, 32, 32); }
                if (sprite_view16.Image != null) { g.DrawImage(sprite_view16.Image, 96, 64, 32, 32); }
                if (sprite_view17.Image != null) { g.DrawImage(sprite_view17.Image, 128, 64, 32, 32); }
                if (sprite_view18.Image != null) { g.DrawImage(sprite_view18.Image, 160, 64, 32, 32); }

                if (sprite_view19.Image != null) { g.DrawImage(sprite_view19.Image, 0, 96, 32, 32); }
                if (sprite_view20.Image != null) { g.DrawImage(sprite_view20.Image, 32, 96, 32, 32); }
                if (sprite_view21.Image != null) { g.DrawImage(sprite_view21.Image, 64, 96, 32, 32); }
                if (sprite_view22.Image != null) { g.DrawImage(sprite_view22.Image, 96, 96, 32, 32); }
                if (sprite_view23.Image != null) { g.DrawImage(sprite_view23.Image, 128, 96, 32, 32); }
                if (sprite_view24.Image != null) { g.DrawImage(sprite_view24.Image, 160, 96, 32, 32); }

                if (sprite_view25.Image != null) { g.DrawImage(sprite_view25.Image, 0, 128, 32, 32); }
                if (sprite_view26.Image != null) { g.DrawImage(sprite_view26.Image, 32, 128, 32, 32); }
                if (sprite_view27.Image != null) { g.DrawImage(sprite_view27.Image, 64, 128, 32, 32); }
                if (sprite_view28.Image != null) { g.DrawImage(sprite_view28.Image, 96, 128, 32, 32); }
                if (sprite_view29.Image != null) { g.DrawImage(sprite_view29.Image, 128, 128, 32, 32); }
                if (sprite_view30.Image != null) { g.DrawImage(sprite_view30.Image, 160, 128, 32, 32); }

                if (sprite_view31.Image != null) { g.DrawImage(sprite_view31.Image, 0, 160, 32, 32); }
                if (sprite_view32.Image != null) { g.DrawImage(sprite_view32.Image, 32, 160, 32, 32); }
                if (sprite_view33.Image != null) { g.DrawImage(sprite_view33.Image, 64, 160, 32, 32); }
                if (sprite_view34.Image != null) { g.DrawImage(sprite_view34.Image, 96, 160, 32, 32); }
                if (sprite_view35.Image != null) { g.DrawImage(sprite_view35.Image, 128, 160, 32, 32); }
                if (sprite_view36.Image != null) { g.DrawImage(sprite_view36.Image, 160, 160, 32, 32); }

                if (sprite_view37.Image != null) { g.DrawImage(sprite_view37.Image, 0, 192, 32, 32); }
                if (sprite_view38.Image != null) { g.DrawImage(sprite_view38.Image, 32, 192, 32, 32); }
                if (sprite_view39.Image != null) { g.DrawImage(sprite_view39.Image, 64, 192, 32, 32); }
                if (sprite_view40.Image != null) { g.DrawImage(sprite_view40.Image, 96, 192, 32, 32); }
                if (sprite_view41.Image != null) { g.DrawImage(sprite_view41.Image, 128, 192, 32, 32); }
                if (sprite_view42.Image != null) { g.DrawImage(sprite_view42.Image, 160, 192, 32, 32); }

                if (sprite_view43.Image != null) { g.DrawImage(sprite_view43.Image, 0, 224, 32, 32); }
                if (sprite_view44.Image != null) { g.DrawImage(sprite_view44.Image, 32, 224, 32, 32); }
                if (sprite_view45.Image != null) { g.DrawImage(sprite_view45.Image, 64, 224, 32, 32); }
                if (sprite_view46.Image != null) { g.DrawImage(sprite_view46.Image, 96, 224, 32, 32); }
                if (sprite_view47.Image != null) { g.DrawImage(sprite_view47.Image, 128, 224, 32, 32); }
                if (sprite_view48.Image != null) { g.DrawImage(sprite_view48.Image, 160, 224, 32, 32); }
            }

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Tibia Sprite|*.bmp";
            savefile.Title = "48 sprites to 1 image";
            savefile.FileName = "myoutfit.bmp";
            savefile.ShowDialog();

            if (savefile.FileName != "")
            {
                FileStream fs = (FileStream)savefile.OpenFile();
                bmp.Save(fs, ImageFormat.Bmp);
                fs.Dispose();
            }

            else
            {
                MessageBox.Show("You need to choose a name to the file.\nExportation incomplete.", "::ERROR::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        //Botão ABOUT
        #region botão ABOUT
        private void about_button_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
        #endregion
    }
}
