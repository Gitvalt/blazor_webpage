import "bootstrap";

////// Also available from @uifabric/icons (7 and earlier) and @fluentui/font-icons-mdl2 (8+)

////import React, { useState, useEffect } from "react"
////import ReactDOM from "react-dom"
////import "babel-polyfill";
////import "bootstrap";

////function IsStringEmpty(value) {
////    return value == null || value == undefined || value.trim() == '';
////}

////const ProjectGallery = (props) => {
////    //const [users, setUsers] = useState({ is_loaded: false, values: [] });

////    useEffect(() => {
////        if (error == null || error == undefined || error == "") {
////            console.log(`Current states in error handle:
////                currentUser.is_loaded: ${currentUser.is_loaded},
////                users.is_loaded: ${users.is_loaded},
////                callHandleCreated null?: ${callHandleCreated != null}`);

////            if (!currentUser.is_loaded) {
////                get_user_data(props.thingsUserID, async (data) => {
////                    if (data.isValid) {
////                        console.log("Creating call handle");

////                        setCurrentUser({
////                            is_loaded: true,
////                            id: data.azureID,
////                            token: data.token.trim(),
////                            name: data.name.trim(),
////                        });

////                        initialize_call_client(data.name.trim(), data.token.trim(), null,
////                            (err) => {
////                                console.error("Initialization of call agent failed");
////                                _errMsg = err;
////                                setError(_errMsg);
////                            });
////                    }
////                }, (errMessage) => {
////                    _errMsg = errMessage;
////                    setError(_errMsg);
////                });
////            }
////            else if (!callHandleCreated) {
////                initialize_call_client(currentUser.name.trim(), currentUser.token.trim(), null, (err) => {
////                    console.error("Initialization of call agent failed");
////                    _errMsg = err;
////                    setError(_errMsg);
////                });
////            }

////            if (!users.is_loaded) {
////                get_group_users(props.categoryId, (data) => {
////                    if (data != null && data != undefined) {
////                        if (data.isValid) {
////                            console.log("Setting group users");

////                            var inputs = data.users;

////                            if (inputs != null && inputs.length > 0) {
////                                inputs.forEach(i => (i.image == null || i.image == undefined) ? props.image_placeholder : i.image);
////                            }

////                            console.log(inputs);

////                            setUsers({
////                                is_loaded: true,
////                                values: inputs
////                            });
////                        }
////                    }
////                }, (errMessage) => {
////                    _errMsg = errMessage;
////                    setError(_errMsg);
////                });
////            }
////        }
////    }, [error]);

////    const render = () => {
////        console.log("Render");

////        return (
////            <div>
////                <p>The hamster is a rat</p>
////            </div>
////        )
////    }

////    return render();
////}

////export function RenderProjectGalleryView(rootElement, props) {
////    ReactDOM.render(<ProjectGallery />, rootElement);
////}

////window.RenderProjectGalleryView = RenderProjectGalleryView;