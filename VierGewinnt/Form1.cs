using System.Windows.Forms;

namespace VierGewinnt
{
    public partial class Form1 : Form
    {
        private TableLayoutPanel _buttonPanel = new TableLayoutPanel();
        private TableLayoutPanel _tableLayoutPanel1 = new TableLayoutPanel();
        private Spiellogik spiel = new Spiellogik();

        private void Button_Click(object sender, EventArgs e)
        {
            int spalte = GetSpalteFromButton((Button)sender); // Hilfsmethode
            if (spiel.ZugSpielen(spalte))
            {
                UpdateBoard(spiel.GibSpielfeld()); // Zeige neues Spielfeld an
                spiel.NächsterSpieler();
            }
        }
        public Form1()
        {
            InitializeComponent();
            this.Text = "Vier Gewinnt";

            SpielfeldErstellen();
            ButtonsErstellen();
            _tableLayoutPanel1.Dock = DockStyle.Fill;
            _buttonPanel.Dock = DockStyle.Top;
            this.Controls.Add(_tableLayoutPanel1);
            this.Controls.Add(_buttonPanel);
        }
        private void ButtonsErstellen()
        {
            _buttonPanel.ColumnCount = 7;
            _buttonPanel.RowCount = 1;

            //größe der Zellen Anpassen
            _buttonPanel.ColumnStyles.Clear();
            _buttonPanel.RowStyles.Clear();
            for (int i = 0; i < 7; i++)
                _buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / 7));

            for (int i = 0; i < 6; i++)
                _buttonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 7));

            for (int col = 0; col < 7; col++)
            {
                Button button = new Button();
                button.BackColor = Color.Gray;
                button.Dock = DockStyle.Fill;
                button.Margin = new Padding(1);
                _buttonPanel.Controls.Add(button, col, 0);
            }
        }
        private void SpielfeldErstellen()
        {
            _tableLayoutPanel1.ColumnCount = 7;
            _tableLayoutPanel1.RowCount = 6;

            _tableLayoutPanel1.Size = new Size(700, 600);
            _tableLayoutPanel1.Location = new Point(10, 10);

            //größe der Zellen Anpassen
            _tableLayoutPanel1.ColumnStyles.Clear();
            _tableLayoutPanel1.RowStyles.Clear();
            for (int i = 0; i < 7; i++)
                _tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / 7));

            for (int i = 0; i < 6; i++)
                _tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 7));


            _tableLayoutPanel1.BackColor = Color.Blue;
            _tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            StartWerte(_tableLayoutPanel1);//Anfangswerte in die felder legen
        }
        private void StartWerte(TableLayoutPanel tableLayoutPanel1)
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Label label = new Label();
                    label.BackColor = Color.White;
                    label.Dock = DockStyle.Fill;
                    label.Margin = new Padding(2);
                    tableLayoutPanel1.Controls.Add(label, col, row);
                }
            }
        }
        public void UpdateBoard(int[,] spielfeld)
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Label label = (Label)_tableLayoutPanel1.GetControlFromPosition(col, row);
                    switch (spielfeld[row, col])
                    {
                        case 0: label.BackColor = Color.White; break;
                        case 1: label.BackColor = Color.Red; break;
                        case 2: label.BackColor = Color.Yellow; break;
                    }
                }
            }
        }
        private int GetSpalteFromButton(Button button)
        {
            return (int)button.Tag;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
