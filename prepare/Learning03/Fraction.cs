using System;

public class Fraction {
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int wholeTop, int wholeBottom)
    {
        _top = wholeTop;
        _bottom = wholeBottom;
    }


    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }


    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }
    
    public double GetDecimcalValue()
    {
        double value = (double)_top/(double)_bottom;
        return value;
    }
}