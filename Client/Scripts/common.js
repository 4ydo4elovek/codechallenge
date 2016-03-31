var node1;
var node2;

$.ajax({
    url: "/home/getnodes",
    type: "POST",
    dataType: "json",
    async: "false",
    success: function (some) {
        // create an array with nodes
        var nodes = new vis.DataSet();
        $(some).each(function (s, elem) {
            nodes.add({ id: elem.Idk__BackingField, label: elem.Labelk__BackingField });
        });

        // create an array with edges
        var tmpEdges = [];
        var edges = new vis.DataSet();
        $(some).each(function (s, elem) {
            for (var k = 0; k < elem.Linesk__BackingField.length; k++) {
                var isExist = false;
                for (var i = 0; i < tmpEdges.length; i++) {
                    if (tmpEdges[i].from === elem.Linesk__BackingField[k].NodeIdFrom && tmpEdges[i].to === elem.Linesk__BackingField[k].NodeIdTo
                        || tmpEdges[i].from === elem.Linesk__BackingField[k].NodeIdTo && tmpEdges[i].to === elem.Linesk__BackingField[k].NodeIdFrom) {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist) {
                    tmpEdges.push({ from: elem.Linesk__BackingField[k].NodeIdFrom, to: elem.Linesk__BackingField[k].NodeIdTo, id: elem.Linesk__BackingField[k].Id});
                }
            }
        });

        // create an array with edges
        for (var j = 0; j < tmpEdges.length; j++) {
            edges.add(tmpEdges[j]);
        }

        // create a network
        var container = document.getElementById('mynetwork');
        var data = {
            height: '100%',
            width: '100%',
            nodes: nodes,
            edges: edges
        };
        var options = {};
        var network = new vis.Network(container, data, options);

        network.on("click", function(params) {
            node2 = node1;
            node1 = params.nodes[0];
            $("#node2").html($("#node1").html());
            $("#node1").html(network.body.nodes[params.nodes[0]].labelModule.lines[0]);
        });
    }
});

$("#btnCalclulatePath").click(function () {
    if (node1 != undefined && node2 != undefined && node1 !== node2) {
        var data = { from: node1, to: node2 };
        $.ajax({
            url: "/home/getshortestpath",
            type: "POST",
            data: data,
            dataType: "json",
            success: function(result) {
                $("#length").html(result.length + " lines");
                var path ="";
                $(result.nodes).each(function (i, e) {
                    path += e.Labelk__BackingField + " ";
                });
                $("#how").html(path);
            }
        });
    } else {
        alert("Choose 2 nodes.");
    }
});