//
//  RegistrationView.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 31.05.2023.
//

import SwiftUI

struct RegistrationView: View {


    @State private var email = ""
    @State private var password = ""
    @State private var firstName = ""
    @State private var lastName = ""
    @State private var isAccepting = false
    @State private var goToGardenView = false
    @ObservedObject private var singleton = Singleton.shared
    var disableForm: Bool {
        password.count < 6 || email.count < 5 || firstName.isEmpty || lastName.isEmpty || isAccepting == false
    }
    var body: some View {
        NavigationView{
            VStack{
                Spacer()
                Text("Welcome back. Enter your credentials to access your account")
                        .foregroundColor(.gray)
                        .font(.body)
                        .multilineTextAlignment(.center)
                
                Group{
                    Spacer()
                    Spacer()
                    Spacer()
                    Spacer()
                }
                Group{
                    Group{
                        TextField("First name", text: $firstName)
                        Spacer()
                        TextField("Last name", text: $lastName)
                        Spacer()
                        TextField("Email Adress", text: $email)
                        Spacer()
                        SecureField("Password", text: $password)
                        Spacer()
                    }
                    .font(.title2)
                    HStack{
                        Toggle( isOn: $isAccepting, label: {
                            Text("I've read and accept the terms & conditions.")
                                .font(.body)
                                .foregroundColor(.black)
                        })
                            .padding(5)
                            .font(.title2)
                            .toggleStyle(iOSCheckboxToggleStyle())
                        Spacer()
                        Spacer()
                    }
                }
                Spacer()
                NavigationLink(destination: CGView{RootView()}, isActive: $singleton.isLoged) {EmptyView()}
                Button{
                    self.goToGardenView = true
                } label: {
                    Text("Continue")
                        .frame(maxWidth: .infinity)
                        .font(.title2)
                }
                .disabled(disableForm)
                .buttonStyle(.borderedProminent)
                Group{
                    Spacer()
                    Spacer()
                    Spacer()
                    Spacer()
                    Spacer()
                    Spacer()
                }
            }
            .textFieldStyle(.roundedBorder)
            .padding(10)
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .principal) {
                    VStack {
                        Text("Sign up")
                            .font(.system(size: 40).bold())
                          .foregroundColor(Color.black)
                    }
                }
            }


        }
    }
    func verifyCredentials () -> Void{
    }
    func googleLogin () -> Void{
    }
}

struct RegistrationView_Previews: PreviewProvider {
    static var previews: some View {
        Group {
            RegistrationView()
        }
    }
}
