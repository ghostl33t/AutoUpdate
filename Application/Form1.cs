using Application.Classes;

namespace Application;
public partial class frmImelUpdate : Form
{
    private readonly Validations.Validations _validations = new();
    private readonly GetData _getData = new();
    private readonly PostData _postData = new();

    private SetupUpdate _update = new();
    private SetupUpdateLocal _updateLocal = new();
    public frmImelUpdate()
    {
        InitializeComponent();
    }

    private async void frmImelUpdate_Load(object sender, EventArgs e)
    {
        _update = await _getData.GetSetupAsync();
        _updateLocal = await _getData.GetSetupLocalAsync();
        if(_update != null)
        {
            txtMinutesForUpdate.Text = _update.RepeatUpdateMinutes.ToString();
            txtMinutesForDeleteUpdate.Text = _update.ClearDLLTableMinutes.ToString();
            txtDLL.Text = _update.DLLServerPath;
            txtOther.Text = _update.OtherServerPath;
        }
        if(_updateLocal != null)
        {
            txtDLLLocal.Text = _updateLocal.DLLLocalPath;
            txtOtherLocal.Text = _updateLocal.OtherLocalPath;
        }
    }

    private async void btnAccept_Click(object sender, EventArgs e)
    {
        if(_update.Id == 0)
        {
            await _postData.CreateSetupAsync(_update);
        }
        else
        {

        }
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btnDLL_Click(object sender, EventArgs e)
    {
        using (var folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.Description = "Odaberite putanju do DLLova na serveru";
            folderBrowserDialog.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                txtDLL.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
    private void btnOther_Click(object sender, EventArgs e)
    {
        using (var folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.Description = "Odaberite putanju do ostalih fajlova na serveru";
            folderBrowserDialog.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                txtOther.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }

    private void btnDLLLocal_Click(object sender, EventArgs e)
    {
        using (var folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.Description = "Odaberite putanju do DLLova na ra�unaru";
            folderBrowserDialog.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                txtDLLLocal.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
    private void btnOtherLocal_Click(object sender, EventArgs e)
    {
        using (var folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.Description = "Odaberite putanju do ostalih fajlova na ra�unaru";
            folderBrowserDialog.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                txtOtherLocal.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }

    private void txtMinutesForUpdate_TextChanged(object sender, EventArgs e)
    {
        _update.RepeatUpdateMinutes = Convert.ToInt16(txtMinutesForUpdate.Text);
    }

    private void txtMinutesForDeleteUpdate_TextChanged(object sender, EventArgs e)
    {
        _update.ClearDLLTableMinutes = Convert.ToInt16(txtMinutesForDeleteUpdate.Text);
    }

    private void txtDLL_TextChanged(object sender, EventArgs e)
    {
        _update.DLLServerPath = txtDLL.Text;
    }

    private void txtOther_TextChanged(object sender, EventArgs e)
    {
        _update.OtherServerPath = txtOther.Text;
    }

    private void txtDLLLocal_TextChanged(object sender, EventArgs e)
    {
        _updateLocal.DLLLocalPath = txtDLLLocal.Text;
    }

    private void txtOtherLocal_TextChanged(object sender, EventArgs e)
    {
        _updateLocal.OtherLocalPath = txtOtherLocal.Text;
    }
}