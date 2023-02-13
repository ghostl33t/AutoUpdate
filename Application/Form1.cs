using Application.Classes;

namespace Application;
public partial class frmImelUpdate : Form
{
    private readonly GetData _getData = new();
    private readonly PostData _postData = new();
    private SetupUpdate _update = new();
    private int _newRecord = 0;
    public frmImelUpdate()
    {
        InitializeComponent();
    }

    private async void frmImelUpdate_Load(object sender, EventArgs e)
    {
        _update = await _getData.GetSetupAsync();

        if(_update != null)
        {
            _newRecord = 0;
            txtMinutesForUpdate.Text = _update.RepeatUpdateMinutes.ToString();
            txtMinutesForDeleteUpdate.Text = _update.ClearDLLTableMinutes.ToString();
            txtDLL.Text = _update.DLLServerPath;
            txtOther.Text = _update.OtherServerPath;
        }
        else
        {
            _newRecord = 1;
        }
    }

    private async void btnAccept_Click(object sender, EventArgs e)
    {
        _update.DLLServerPath = txtDLL.Text;
        _update.OtherServerPath = txtOther.Text;
        _update.ClearDLLTableMinutes = Convert.ToInt16(txtMinutesForDeleteUpdate.Text);
        _update.RepeatUpdateMinutes = Convert.ToInt16(txtMinutesForUpdate.Text);

        if(_newRecord == 1)
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

    
}