# xUnit.net Specifications #
http://github.com/ArnoldZokas/xUnit.net-Specifications
<br />
## 1. Overview ##

On August 24 2008, Phil Haack published a blog post titled "Streamlined BDD Using SubSpec for xUnit.NET" (http://haacked.com/archive/2008/08/24/introducing-subspec.aspx).

In his post he wrote about an idea he had for syntax he would like to use with BDD unit tests.

His idea was implemented by Brad Wilson in xUnit.net changeset 22555 and can be be found at http://xunit.codeplex.com/SourceControl/changeset/view/d947e347c5c3#Samples%2fSpecificationExamples%2fSubSpec%2fSpecificationExtensions.cs.

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

## 3. Related Links ##

+ You can download the latest version of xUnit.net from http://xunit.codeplex.com/releases/view/31606
+ You can read Phil Haack's original blog post at http://haacked.com/archive/2008/08/24/introducing-subspec.aspx

## 4. Acknowledgements ##

Thanks to Phil Haack coming up with this unit test syntax and posting about it on his blog.

Thanks to Brad Wilson for writing the original implementation.
<br />
<br />
<br />
Thanks for using xUnit Specifications,<br />
Arnold Zokas