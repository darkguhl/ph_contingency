this["PH"] = this["PH"] || {};
this["PH"]["Templates"] = this["PH"]["Templates"] || {};
this["PH"]["Templates"]["Stars"] = Handlebars.template({"1":function(depth0,helpers,partials,data) {
    var helper, alias1=helpers.helperMissing, alias2="function", alias3=this.escapeExpression;

  return "<div style=\"position:relative; top: "
    + alias3(((helper = (helper = helpers.Y || (depth0 != null ? depth0.Y : depth0)) != null ? helper : alias1),(typeof helper === alias2 ? helper.call(depth0,{"name":"Y","hash":{},"data":data}) : helper)))
    + "px; left: "
    + alias3(((helper = (helper = helpers.X || (depth0 != null ? depth0.X : depth0)) != null ? helper : alias1),(typeof helper === alias2 ? helper.call(depth0,{"name":"X","hash":{},"data":data}) : helper)))
    + "px;\">\r\n    <table>\r\n        <tr>\r\n            <td rowspan=\"2\" style=\"width: 50px; height: 50px;\" class=\"star star-icon type-"
    + alias3(((helper = (helper = helpers.CssClass || (depth0 != null ? depth0.CssClass : depth0)) != null ? helper : alias1),(typeof helper === alias2 ? helper.call(depth0,{"name":"CssClass","hash":{},"data":data}) : helper)))
    + "\"></td>\r\n            <td class=\"star star-name\">"
    + alias3(((helper = (helper = helpers.Name || (depth0 != null ? depth0.Name : depth0)) != null ? helper : alias1),(typeof helper === alias2 ? helper.call(depth0,{"name":"Name","hash":{},"data":data}) : helper)))
    + "</td>\r\n        </tr>\r\n        <tr>\r\n            <td>"
    + alias3(((helper = (helper = helpers.Name || (depth0 != null ? depth0.Name : depth0)) != null ? helper : alias1),(typeof helper === alias2 ? helper.call(depth0,{"name":"Name","hash":{},"data":data}) : helper)))
    + "</td>\r\n        </tr>\r\n    </table>\r\n</div>\r\n";
},"compiler":[6,">= 2.0.0-beta.1"],"main":function(depth0,helpers,partials,data) {
    var stack1;

  return ((stack1 = helpers.each.call(depth0,(depth0 != null ? depth0.stars : depth0),{"name":"each","hash":{},"fn":this.program(1, data, 0),"inverse":this.noop,"data":data})) != null ? stack1 : "");
},"useData":true});