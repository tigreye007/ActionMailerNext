﻿#region License
/* Copyright (C) 2012 by Scott W. Anderson
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion

using System;
using System.Web.Mvc;
using System.Web.Routing;
using FakeItEasy;
using NUnit.Framework;

namespace ActionMailer.Net.Mvc5_2.Tests.Mvc5_2
{
    [TestFixture]
    public class UrlHelperExtensionsTests {
        private readonly UrlHelper _helper;

        public UrlHelperExtensionsTests() {
            _helper = GetUrlHelper();
        }

        [Test]
        public void AbsoluteActionWithAction() {
            var expectedUrl = String.Format("http://localhost{0}/app/home/test", MvcHelper.AppPathModifier);
            
            var generatedUrl = _helper.AbsoluteAction("test");

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteActionWithActionAndRouteData() {
            var expectedUrl = String.Format("http://localhost{0}/app/admin/test", MvcHelper.AppPathModifier);

            var generatedUrl = _helper.AbsoluteAction("test", new {controller = "admin"});

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteActionWithActionAndRouteDictionary() {
            var values = new RouteValueDictionary(new {controller = "admin", id = "12345"});
            var expectedUrl = String.Format("http://localhost{0}/app/admin/test/12345", MvcHelper.AppPathModifier);

            var generatedUrl = _helper.AbsoluteAction("test", values);

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteActionWithActionAndControllerName() {
            var expectedUrl = String.Format("http://localhost{0}/app/admin/test", MvcHelper.AppPathModifier);

            var generatedUrl = _helper.AbsoluteAction("test", "admin");

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteActionWithActionAndControllerAndRouteValues() {
            var expectedUrl = String.Format("http://localhost{0}/app/admin/test/12345", MvcHelper.AppPathModifier);

            var generatedUrl = _helper.AbsoluteAction("test", "admin", new {id = "12345"});

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteActionWithActionAndControllerAndRouteDictionary() {
            var expectedUrl = String.Format("http://localhost{0}/app/admin/test/12345", MvcHelper.AppPathModifier);
            var values = new RouteValueDictionary(new {id = "12345"});

            var generatedUrl = _helper.AbsoluteAction("test", "admin", values);

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteActionWithActionAndControllerAndRouteValuesAndProtocol() {
            var expectedUrl = String.Format("https://localhost{0}/app/admin/test/12345", MvcHelper.AppPathModifier);

            var generatedUrl = _helper.AbsoluteAction("test", "admin", new { id = "12345" }, "https");

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteActionWithActionAndControllerAndRouteDictionaryAndProtocolAndHostname() {
            var expectedUrl = String.Format("https://google.com{0}/app/admin/test/12345", MvcHelper.AppPathModifier);
            var values = new RouteValueDictionary(new {id = "12345"});

            var generatedUrl = _helper.AbsoluteAction("test", "admin", values, "https", "google.com");
            

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteRouteUrlWithRouteName() {
            var expectedUrl = String.Format("http://localhost{0}/app/named/home/oldaction", MvcHelper.AppPathModifier);

            var generatedUrl = _helper.AbsoluteRouteUrl("namedroute");

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteRouteUrlWithRouteValues() {
            var expectedUrl = String.Format("http://localhost{0}/app/home/oldaction/12345", MvcHelper.AppPathModifier);

            var generatedUrl = _helper.AbsoluteRouteUrl(new {id = "12345"});

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteRouteUrlWithRouteDictionary() {
            var expectedUrl = String.Format("http://localhost{0}/app/home/oldaction/12345", MvcHelper.AppPathModifier);
            var values = new RouteValueDictionary(new {id = "12345"});

            var generatedUrl = _helper.AbsoluteRouteUrl(values);

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteRouteUrlWithRouteNameAndRouteValues() {
            var expectedUrl = String.Format("http://localhost{0}/app/named/home/oldaction/12345", MvcHelper.AppPathModifier);

            var generatedUrl = _helper.AbsoluteRouteUrl("namedroute", new {id = "12345"});

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteRouteUrlWithRouteNameAndRouteDictionary() {
            var expectedUrl = String.Format("http://localhost{0}/app/named/home/oldaction/12345", MvcHelper.AppPathModifier);
            var values = new RouteValueDictionary(new { id = "12345" });

            var generatedUrl = _helper.AbsoluteRouteUrl("namedroute", values);

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteRouteUrlWithRouteNameAndRouteValuesAndProtocol() {
            var expectedUrl = String.Format("https://localhost{0}/app/named/home/oldaction/12345", MvcHelper.AppPathModifier);

            var generatedUrl = _helper.AbsoluteRouteUrl("namedroute", new {id = "12345"}, "https");

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteRouteUrlWithRouteNameAndRouteDictionaryAndProtocolAndHostname() {
            var expectedUrl = String.Format("https://google.com{0}/app/named/home/oldaction/12345", MvcHelper.AppPathModifier);
            var values = new RouteValueDictionary(new { id = "12345" });

            var generatedUrl = _helper.AbsoluteRouteUrl("namedroute", values, "https", "google.com");

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        [Test]
        public void AbsoluteContent() {
            var expectedUrl = String.Format("http://localhost/app/content/abc.txt");

            var generatedUrl = _helper.AbsoluteContent("~/content/abc.txt");

            Assert.AreEqual(expectedUrl, generatedUrl);
        }

        #region Helpers taken from MVC 3 source.
        private static RouteCollection GetRouteCollection() {
            var rt = new RouteCollection
            {
                new Route("{controller}/{action}/{id}", null)
                {
                    Defaults = new RouteValueDictionary(new {id = "defaultid"})
                },
                {
                    "namedroute",
                    new Route("named/{controller}/{action}/{id}", null)
                    {
                        Defaults = new RouteValueDictionary(new {id = "defaultid"})
                    }
                }
            };
            
            return rt;
        }

        private static RouteData GetRouteData() {
            var rd = new RouteData();
            rd.Values.Add("controller", "home");
            rd.Values.Add("action", "oldaction");
            return rd;
        }

        private static UrlHelper GetUrlHelper() {
            return GetUrlHelper(GetRouteData(), GetRouteCollection());
        }

        private static UrlHelper GetUrlHelper(RouteData routeData = null, RouteCollection routeCollection = null)
        {

            var httpcontext = MvcHelper.GetHttpContext("/app/", null, null);
            var urlHelper = new UrlHelper(new RequestContext(httpcontext, routeData ?? new RouteData()), routeCollection ?? new RouteCollection());
            return urlHelper;
        }
        #endregion
    }
}
