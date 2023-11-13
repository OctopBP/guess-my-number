using TMPro;

namespace Game
{
    class ResultView
    {
        readonly TMP_Text resultText;
        
        public ResultView(TMP_Text resultText)
        {
            this.resultText = resultText;
        }

        public void SetResult(RoundData roundData)
        {
            resultText.SetText($"You get this for {roundData.guesses.Count} guesses!");
        }
        
        public void Reset()
        {
            resultText.SetText("??");
        }
    }
}