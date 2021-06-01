<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <style>
body > div {
  border: 1px solid black;
  display: inline-block;
  float: left;
  padding: 2%;
  margin: .5%;
}
td {
  text-align: center;
}
.category {
  border: 1px solid gray;
  padding: 1%;
}
        </style>
      </head>
      <body>
        <div>
          <h1>Products</h1>
          <div>
            <xsl:for-each select="store/categories/category">
              <div class="category">
                <h3>
                  Category:
                  <!--Fruit-->
                  <xsl:value-of select="@name"/>
                </h3>
                <div>
                  <table>
                    <tr>
                      <th>Name</th>
                      <th>Price</th>
                    </tr>
                    <xsl:for-each select="product">
                      <tr>
                        <td>
                          <xsl:value-of select="name"/>
                        </td>
                        <td>
                          <xsl:value-of select="price"/>
                        </td>
                      </tr>
                    </xsl:for-each>
                  </table>
                </div>
              </div>
            </xsl:for-each>
          </div>
        </div>
        <div>
          <h1>Employees</h1>
          <div>
            <table>
              <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Rank</th>
                <th>Employment Date</th>
                <th>Additional Note</th>
              </tr>
              <tr>
                <td>
                  <xsl:value-of select="store/employees/manager/@id"/>
                </td>
                <td>
                  <xsl:value-of select="store/employees/manager/name"/>
                </td>
                <td>Manager</td>
                <td>
                  <xsl:value-of select="store/employees/manager/employment-date"/>
                </td>
                <xsl:choose>
                  <xsl:when test="store/employees/manager/@eotm">
                    <td>Employee of the Month</td>
                  </xsl:when>
                  <xsl:otherwise>
                    <td></td>
                  </xsl:otherwise>
                </xsl:choose>
                <td></td>
              </tr>
              <xsl:for-each select="store/employees/stock-managers/stock-manager">
                <tr>
                  <td>
                    <xsl:value-of select="@id"/>
                  </td>
                  <td>
                    <xsl:value-of select="name"/>
                  </td>
                  <td>Stock Manager</td>
                  <td>
                    <xsl:value-of select="employment-date"/>
                  </td>
                  <xsl:choose>
                    <xsl:when test="@eotm">
                      <td>Employee of the Month</td>
                    </xsl:when>
                    <xsl:otherwise>
                      <td></td>
                    </xsl:otherwise>
                  </xsl:choose>
                </tr>
              </xsl:for-each>
              <xsl:for-each select="store/employees/cashiers/cashier">
                <tr>
                  <td>
                    <xsl:value-of select="@id"/>
                  </td>
                  <td>
                    <xsl:value-of select="name"/>
                  </td>
                  <td>Cashier</td>
                  <td>
                    <xsl:value-of select="employment-date"/>
                  </td>
                  <xsl:if test="@eotm">
                    <td>Employee of the Month</td>
                  </xsl:if>
                </tr>
              </xsl:for-each>
            </table>
          </div>
        </div>
      </body>
    </html>

  </xsl:template>
</xsl:stylesheet>