using DotNet_Design_Patterns_Vol2.Chapter_08.TransformView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace DotNet_Design_Patterns_Vol2.Chapter_08.TwoStepView
{
    public class FirstStepAuthor
    {
        public void FirstStepTransformer()
        {
            var myXslTrans = new XslCompiledTransform();
            myXslTrans.Load(@"Chapter 08\TwoStepView\firststep-style.xslt");
            myXslTrans.Transform(@"Chapter 08\TwoStepView\input.xml", @"Chapter 08\TwoStepView\logical.xml");
        }
    }
    public class SecondStepAuthor
    {
        public void SecondStepTransformer()
        {
            var myXslTrans = new XslCompiledTransform();
            myXslTrans.Load(@"Chapter 08\TwoStepView\secondstep-style.xslt");
            myXslTrans.Transform(@"Chapter 08\TwoStepView\logical.xml", @"Chapter 08\TwoStepView\output.html");
        }
    }
}
