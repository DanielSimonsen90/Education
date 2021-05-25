<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">

<html>
    <body>
        <h1>Products</h1>
        <button id="sorter">Now sorting by: name</button>
        <table>
            <tr>
                <th>Name</th>
                <th>Price</th>
            </tr>
            <xsl:for-each select="store/category/product">
                <!-- <xsl:if test="price &gt; 10"> -->
                <!-- <xsl:choose>
                     <xsl:when test="1=1"> -->
                        <xsl:sort select="name"/>
                    <!-- </xsl:when>
                    <xsl:otherwise>
                        <xsl:sort select="price"/>
                    </xsl:otherwise>
                </xsl:choose> -->
                <tr style="text-align: center;">
                    <td><xsl:value-of select="name"/></td>
                    <td><xsl:value-of select="price"/></td>
                </tr>
                <!-- </xsl:if> -->
            </xsl:for-each>
        </table>
    </body>
</html>

</xsl:template>
</xsl:stylesheet>