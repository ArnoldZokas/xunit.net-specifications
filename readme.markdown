# xUnit.net Specifications #
## 1. Overview ##

On August 24 2008, Phil Haack published a blog post titled <a href="http://haacked.com/archive/2008/08/24/introducing-subspec.aspx">"Streamlined BDD Using SubSpec for xUnit.NET"</a>.

In his post he wrote about an idea he had for syntax he would like to use with BDD unit tests.

His idea was implemented by Brad Wilson in <a href="http://xunit.codeplex.com/SourceControl/changeset/view/d947e347c5c3#Samples%2fSpecificationExamples%2fSubSpec%2fSpecificationExtensions.cs">xUnit.net changeset 22555</a>.

After using this syntax on a couple of personal projects, I have decided to extract the relevant code and publish it on GitHub as a standalone project. This is the result.

## 2. Usage Instructions ##

This project is currently compiled against xUnit.net 1.5.0.1479 (release 1.5).

To use it, you need to reference assembly xunit.specifications.dll in your test project.

Here's a sample specification:

    namespace ProjectName.Specifications
    {
        public class OrderSpecifications
        {
            [Specification]
            public void AddOrderLineSpecifications()
            {
                Order order = null;

                "Given a new order instance".Context(() => order = new ());

                "with order line added to it".Do(() => order.AddOrderLine(null));

                "the number of order lines in the order is 1".Assert(() => Assert.Equal(1, order.OrderLines));
            }
        }
    }

## 3. Build Instructions ##

To build this project on your machine, run batch file <strong>./cfg/build.bat</strong>.
Build output is automatically placed into directory <strong>./_build/</strong>.

## 4. Related Links ##

+ You can download the latest version of xUnit.net from <a href="http://xunit.codeplex.com/releases/view/31606">http://xunit.codeplex.com/releases/view/31606</a>
+ You can read Phil Haack's original blog post at <a href="http://haacked.com/archive/2008/08/24/introducing-subspec.aspx">http://haacked.com/archive/2008/08/24/introducing-subspec.aspx</a>

## 5. Acknowledgements ##

Thanks to Phil Haack coming up with this unit test syntax and posting about it on his blog.<br />
Thanks to Brad Wilson for writing the original implementation.

## 6. License ##

Copyright (c) 2010, Arnold Zokas<br /><br />
This source code is subject to terms and conditions of the New BSD License.<br />
A copy of the license can be found in the license.txt file at the root of this distribution.<br />
If you cannot locate the New BSD License, please send an email to arnold.zokas@coderoom.net.<br />
By using this source code in any fashion, you are agreeing to be bound by the terms of the New BSD License.<br />
You must not remove this notice, or any other, from this software.
<br />
<br />
Thanks for using xUnit Specifications,<br />
Arnold Zokas