public class MathAssignment : Assignment {
    private string _textbookSection ;
    private string _problems ;

    public void SetTextbookSection(string section) {
        _textbookSection = section;
    }

    public void SetProblems(string problems) {
        _problems = problems;
    }

    public string GetHomeworkList() {
        return $"{_textbookSection} {_problems}";
    }

}