using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class QuestionAnswer
{
    Question question;
    float correctness;

    public QuestionAnswer(Question question, float correctness)
    {
        this.question = question;
        this.correctness = correctness;
    }
}
