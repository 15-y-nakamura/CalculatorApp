using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Calculator
{
    internal class TetrisGame
    {
        const int FIELD_HEIGHT = 37;
        const int FIELD_WIDTH = 6;
        int SQUARE_SIZE = 10;
        int[,] field = new int[FIELD_HEIGHT, FIELD_WIDTH];
        int minoX, minoY, minoDir, minoType;
        static readonly int[,,] mino = new int[7, 4, 16]
        {
            { {0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0}, {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0}, {0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0}, {0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0} },
            { {0,0,0,0,0,1,1,0,0,1,1,0,0,0,0,0}, {0,0,0,0,0,1,1,0,0,1,1,0,0,0,0,0}, {0,0,0,0,0,1,1,0,0,1,1,0,0,0,0,0}, {0,0,0,0,0,1,1,0,0,1,1,0,0,0,0,0} },
            { {0,0,0,0,0,1,0,0,1,1,1,0,0,0,0,0}, {0,0,0,0,0,1,0,0,0,1,1,0,0,1,0,0}, {0,0,0,0,0,0,0,0,1,1,1,0,0,1,0,0}, {0,0,0,0,0,1,0,0,1,1,0,0,0,1,0,0} },
            { {0,0,0,0,0,1,1,0,1,1,0,0,0,0,0,0}, {0,0,0,0,1,0,0,0,1,1,0,0,0,1,0,0}, {0,0,0,0,0,1,1,0,1,1,0,0,0,0,0,0}, {0,0,0,0,1,0,0,0,1,1,0,0,0,1,0,0} },
            { {0,0,0,0,1,1,0,0,0,1,1,0,0,0,0,0}, {0,0,0,0,0,1,0,0,1,1,0,0,1,0,0,0}, {0,0,0,0,1,1,0,0,0,1,1,0,0,0,0,0}, {0,0,0,0,0,1,0,0,1,1,0,0,1,0,0,0} },
            { {0,0,0,0,1,0,0,0,1,1,1,0,0,0,0,0}, {0,0,0,0,0,1,1,0,0,1,0,0,0,1,0,0}, {0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,0}, {0,0,0,0,0,1,0,0,0,1,0,0,1,1,0,0} },
            { {0,0,0,0,0,0,1,0,1,1,1,0,0,0,0,0}, {0,0,0,0,0,1,0,0,0,1,0,0,0,1,1,0}, {0,0,0,0,0,0,0,0,1,1,1,0,1,0,0,0}, {0,0,0,0,1,1,0,0,0,1,0,0,0,1,0,0} }
        };

        private Canvas tetrisCanvas;
        private Label displayLabel;
        private Random rnd = new Random();
        private DispatcherTimer timer;
        private bool isGameOver = false;

        public void StartTetris(MainWindow screen)
        {
            MessageBox.Show("Tetrisゲームを開始します！");

            screen.lblDisplay.Content = "";
            screen.subDisplay.Content = "";

            // Grid を回転
            var grid = screen.MainGrid;
            grid.LayoutTransform = new RotateTransform(90);

            screen.Width = 550;
            screen.Height = 455;

            // lblDisplay の位置調整
            screen.lblDisplay.Margin = new Thickness(
                screen.lblDisplay.Margin.Left + 34,
                screen.lblDisplay.Margin.Top,
                screen.lblDisplay.Margin.Right,
                screen.lblDisplay.Margin.Bottom
            );

            // ボタンを無効化
            screen.memory_minus.IsEnabled = false;
            screen.memory_recall_clear.IsEnabled = false;
            screen.plus_minus.IsEnabled = false;
            screen.memory_plus.IsEnabled = false;
            screen.only.IsEnabled = false;
            screen.back_space.IsEnabled = false;
            screen.one.IsEnabled = false;
            screen.two.IsEnabled = false;
            screen.three.IsEnabled = false;
            screen.division.IsEnabled = false;
            screen.clear.IsEnabled = false;
            screen.four.IsEnabled = false;
            screen.five.IsEnabled = false;
            screen.six.IsEnabled = false;
            screen.seven.IsEnabled = false;
            screen.eight.IsEnabled = false;
            screen.zero.IsEnabled = false;
            screen.double_zero.IsEnabled = false;
            screen.decimal_point.IsEnabled = false;
            screen.multiply.IsEnabled = false;

            // 画面回転・ボタン無効化などは省略可
            displayLabel = screen.lblDisplay;
            tetrisCanvas = new Canvas
            {
                Width = displayLabel.Width,
                Height = displayLabel.Height,
                Background = Brushes.Transparent,
                IsHitTestVisible = false
            };

            if (!(displayLabel.Parent is Grid g && g.Children.Contains(tetrisCanvas)))
                (displayLabel.Parent as Grid)?.Children.Add(tetrisCanvas);

            Array.Clear(field, 0, field.Length);
            isGameOver = false;
            NewMino();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += (s, e) => { if (!isGameOver) MoveDown(); };
            timer.Start();

        }


        private void NewMino()
        {
            minoType = rnd.Next(0, 7);
            minoDir = 0;
            minoX = FIELD_WIDTH - 4; ;
            minoY = 0;
            if (IsCollision(minoX, minoY, minoDir))
            {
                isGameOver = true;
                timer?.Stop();
                MessageBox.Show("ゲームオーバー！");

                // MainWindowを再読み込み
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // 現在のMainWindowを閉じる
                    var current = Application.Current.MainWindow;
                    var newWindow = new MainWindow();
                    Application.Current.MainWindow = newWindow;
                    newWindow.Show();
                    current.Close();
                });
                return;
            }
            Draw();
        }

        private bool IsCollision(int x, int y, int dir)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (mino[minoType, dir, i * 4 + j] == 1)
                    {
                        int fx = x + j, fy = y + i;
                        if (fx < 0 || fx >= FIELD_WIDTH || fy < 0 || fy >= FIELD_HEIGHT) return true;
                        if (field[fy, fx] != 0) return true;
                    }
            return false;
        }

        private void FixMino()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (mino[minoType, minoDir, i * 4 + j] == 1)
                    {
                        int fx = minoX + j, fy = minoY + i;
                        if (fx >= 0 && fx < FIELD_WIDTH && fy >= 0 && fy < FIELD_HEIGHT)
                            field[fy, fx] = minoType + 1;
                    }

            ClearLines();
        }

        private void MoveDown()
        {
            if (!IsCollision(minoX, minoY + 1, minoDir))
            {
                minoY++;
                Draw();
            }
            else
            {
                FixMino();
                NewMino();
            }
        }

        public void MoveMino(string command)
        {
            if (isGameOver) return;
            int nx = minoX, ny = minoY, ndir = minoDir;
            switch (command)
            {
                case "+": nx--; break; // 左
                case "-": nx++; break; // 右
                case "x": ndir = (minoDir + 1) % 4; break; // 回転
                case "d": ny++; break; // 下
            }
            if (!IsCollision(nx, ny, ndir))
            {
                minoX = nx; minoY = ny; minoDir = ndir;
                Draw();
            }
            else if (command == "d")
            {
                MoveDown();
            }
        }

        private const int FIELD_OFFSET_Y = 49; // 上側スペース分

        private void Draw()
        {
            tetrisCanvas.Children.Clear();
            // フィールド
            for (int y = 0; y < FIELD_HEIGHT; y++)
                for (int x = 0; x < FIELD_WIDTH; x++)
                    if (field[y, x] != 0)
                    {
                        var rect = new Rectangle
                        {
                            Width = SQUARE_SIZE,
                            Height = SQUARE_SIZE,
                            Fill = Brushes.Gray,
                            Stroke = Brushes.Black
                        };
                        double left = y * SQUARE_SIZE;
                        double top = (FIELD_WIDTH - 1 - x) * SQUARE_SIZE + FIELD_OFFSET_Y;
                        Canvas.SetLeft(rect, left);
                        Canvas.SetTop(rect, top);
                        tetrisCanvas.Children.Add(rect);
                    }
            // ミノ
            var brush = new SolidColorBrush(Color.FromArgb(130, 100, 180, 255));
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (mino[minoType, minoDir, i * 4 + j] == 1)
                    {
                        double left = (minoY + i) * SQUARE_SIZE;
                        double top = (FIELD_WIDTH - 1 - (minoX + j)) * SQUARE_SIZE + FIELD_OFFSET_Y;
                        var rect = new Rectangle
                        {
                            Width = SQUARE_SIZE,
                            Height = SQUARE_SIZE,
                            Fill = brush,
                            Stroke = Brushes.Transparent
                        };
                        Canvas.SetLeft(rect, left);
                        Canvas.SetTop(rect, top);
                        tetrisCanvas.Children.Add(rect);
                    }
        }

        // 1列揃った行を消す
        private void ClearLines()
        {
            for (int y = 0; y < FIELD_HEIGHT; y++)
            {
                bool full = true;
                for (int x = 0; x < FIELD_WIDTH; x++)
                {
                    if (field[y, x] == 0)
                    {
                        full = false;
                        break;
                    }
                }
                if (full)
                {
                    // 上から下にずらす
                    for (int yy = y; yy > 0; yy--)
                    {
                        for (int x = 0; x < FIELD_WIDTH; x++)
                        {
                            field[yy, x] = field[yy - 1, x];
                        }
                    }
                    // 一番上の行を空に
                    for (int x = 0; x < FIELD_WIDTH; x++)
                    {
                        field[0, x] = 0;
                    }
                    y--; // 連続消し対応
                }
            }
        }
    }
}
