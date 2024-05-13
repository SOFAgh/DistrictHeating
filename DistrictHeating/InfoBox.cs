using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace DistrictHeating
{
    public class InfoBox : Form
    {
        private RichTextBox messageBox;
        private Button closeButton;
        private int maxFormWidth;
        private int maxFormHeight;
        //private string urlPattern = @"(http|https)://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?";
        private string urlPattern = @"(http|https):\/\/[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(\/\S*?)?(?=[.,)\s]|$)";

        public InfoBox(string message, string title, int maxWidth, int maxHeight)
        {
            this.maxFormWidth = maxWidth;
            this.maxFormHeight = maxHeight;
            this.Text = title;
            InitializeComponent();
            messageBox.Text = message;
            AdjustFormSize();
            this.messageBox.MouseUp += new MouseEventHandler(messageBox_MouseUp);
            FormatHyperlinks(messageBox);
        }

        private void InitializeComponent()
        {
            this.messageBox = new RichTextBox
            {
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                Location = new Point(10, 10),
                WordWrap = true,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                BackColor = Color.LightYellow
            };

            this.closeButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                //Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };

            this.closeButton.Location = new Point(10, 10); // Temporarily place, will adjust later
            this.closeButton.Click += (sender, e) => { this.Close(); };

            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.closeButton);

            this.AcceptButton = this.closeButton; // Allows Enter key to close dialog

            // Form Settings
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
        }

        public void FormatHyperlinks(RichTextBox richTextBox)
        {
            // URL regular expression pattern
            Regex urlRegex = new Regex(urlPattern);
            MatchCollection matches = urlRegex.Matches(richTextBox.Text);

            foreach (Match match in matches)
            {
                int startIndex = match.Index;
                int length = match.Length;

                // Format the matched text as a hyperlink
                richTextBox.Select(startIndex, length);
                richTextBox.SelectionColor = Color.Blue;
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Underline);
            }

            // Reset selection
            richTextBox.Select(0, 0);
            richTextBox.SelectionColor = Color.Black;
            richTextBox.SelectionFont = richTextBox.Font;
        }
        private void messageBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                RichTextBox richTextBox = sender as RichTextBox;
                int cursorPos = richTextBox.GetCharIndexFromPosition(e.Location);
                string text = richTextBox.Text;

                Regex urlRegex = new Regex(urlPattern);
                MatchCollection matches = urlRegex.Matches(text);

                foreach (Match match in matches)
                {
                    if (cursorPos >= match.Index && cursorPos < match.Index + match.Length)
                    {
                        // Open the hyperlink
                        string link = match.Value.TrimEnd(')', '.');
                        try
                        {
                            Uri uriResult;
                            bool result = Uri.TryCreate(link, UriKind.Absolute, out uriResult)
                                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                            if (result)
                            {
                                Process.Start(new ProcessStartInfo(uriResult.ToString()) { UseShellExecute = true });
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Unable to open the link: " + ex.Message);
                        }
                        break;
                    }
                }
            }
        }

        private void AdjustFormSize()
        {
            // Measure the text size
            Size textSize = TextRenderer.MeasureText(messageBox.Text, messageBox.Font, new Size(maxFormWidth - 20, int.MaxValue), TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
            textSize.Height += 10; // to avoid scrollbar
            int dx = this.Size.Width - this.ClientSize.Width;
            int dy = this.Size.Height - this.ClientSize.Height;
            // Calculate the size of the form based on text size and max constraints
            int formWidth = Math.Min(textSize.Width + dx + 20, maxFormWidth); // +20: Rahmen um textbox
            int formHeight = Math.Min(textSize.Height + dy + 30 + 20 + 20, maxFormHeight); // 30: button, 20 Rahmen Button, 20 Rahmen textbox

            this.Size = new Size(formWidth, formHeight);
            messageBox.Size = new Size(formWidth - dx - 20, formHeight - (dy + 30 + 20));

            // Place close button at the bottom
            closeButton.Size = new Size(80, 30);
            closeButton.Location = new Point(formWidth - dx - 90, formHeight - dy - 30 - 10);
            this.closeButton.BringToFront();
        }
    }
}
