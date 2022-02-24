// Also available from @uifabric/icons (7 and earlier) and @fluentui/font-icons-mdl2 (8+)
"use strict";

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _this = this;

exports.RenderVideoCallerView = RenderVideoCallerView;

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { "default": obj }; }

var _fluentuiReactLibIcons = require('@fluentui/react/lib/Icons');

var _react = require("react");

var _react2 = _interopRequireDefault(_react);

var _reactDom = require("react-dom");

var _reactDom2 = _interopRequireDefault(_reactDom);

require("babel-polyfill");

(0, _fluentuiReactLibIcons.initializeIcons)();

function IsStringEmpty(value) {
    return value == null || value == undefined || value.trim() == '';
}

var ProjectGallery = function ProjectGallery(props) {
    //const [users, setUsers] = useState({ is_loaded: false, values: [] });

    (0, _react.useEffect)(function () {
        if (error == null || error == undefined || error == "") {
            console.log("Current states in error handle:\n                currentUser.is_loaded: " + currentUser.is_loaded + ",\n                users.is_loaded: " + users.is_loaded + ",\n                callHandleCreated null?: " + (callHandleCreated != null));

            if (!currentUser.is_loaded) {
                get_user_data(props.thingsUserID, function callee$2$0(data) {
                    return regeneratorRuntime.async(function callee$2$0$(context$3$0) {
                        while (1) switch (context$3$0.prev = context$3$0.next) {
                            case 0:
                                if (data.isValid) {
                                    console.log("Creating call handle");

                                    setCurrentUser({
                                        is_loaded: true,
                                        id: data.azureID,
                                        token: data.token.trim(),
                                        name: data.name.trim()
                                    });

                                    initialize_call_client(data.name.trim(), data.token.trim(), null, function (err) {
                                        console.error("Initialization of call agent failed");
                                        _errMsg = err;
                                        setError(_errMsg);
                                    });
                                }

                            case 1:
                            case "end":
                                return context$3$0.stop();
                        }
                    }, null, _this);
                }, function (errMessage) {
                    _errMsg = errMessage;
                    setError(_errMsg);
                });
            } else if (!callHandleCreated) {
                initialize_call_client(currentUser.name.trim(), currentUser.token.trim(), null, function (err) {
                    console.error("Initialization of call agent failed");
                    _errMsg = err;
                    setError(_errMsg);
                });
            }

            if (!users.is_loaded) {
                get_group_users(props.categoryId, function (data) {
                    if (data != null && data != undefined) {
                        if (data.isValid) {
                            console.log("Setting group users");

                            var inputs = data.users;

                            if (inputs != null && inputs.length > 0) {
                                inputs.forEach(function (i) {
                                    return i.image == null || i.image == undefined ? props.image_placeholder : i.image;
                                });
                            }

                            console.log(inputs);

                            setUsers({
                                is_loaded: true,
                                values: inputs
                            });
                        }
                    }
                }, function (errMessage) {
                    _errMsg = errMessage;
                    setError(_errMsg);
                });
            }
        }
    }, [error]);

    var render = function render() {
        console.log("Render");

        return _react2["default"].createElement(
            "div",
            null,
            _react2["default"].createElement(
                "p",
                null,
                "The hamster is a rat"
            )
        );
    };

    return render();
};

function RenderVideoCallerView(rootElement, props) {
    _reactDom2["default"].render(_react2["default"].createElement(ProjectGallery, null), rootElement);
}

window.RenderVideoCallerView = RenderVideoCallerView;

